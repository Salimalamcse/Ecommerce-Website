using Ecommerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ecommerce_Website.Controllers
{
    public class CustomerController : Controller
    {
        private myContext _Context;
        private IWebHostEnvironment _env;

        public CustomerController(myContext context, IWebHostEnvironment env)
        {
            _Context = context;
            _env = env;


        }


        //---------------------------Category Drop Down---------------------

        public IActionResult Index()
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

            List<Product> products = _Context.tbl_product.ToList();
            ViewData["product"] = products;

            ViewBag.checkSession = HttpContext.Session.GetString("customerSession");
            return View();
        }
        public IActionResult customerLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult customerLogin(String customerEmail, String customerPassowrd)
        {
            var customer = _Context.tbl_customer.FirstOrDefault(c => c.customer_email == customerEmail);
            if (customer != null && customer.customer_password == customerPassowrd)
            {
                HttpContext.Session.SetString("customerSession",
                customer.customer_Id.ToString());
                return RedirectToAction("Index");

            }
            else
            {
				ViewBag.message = "Incorrect Username or Password";
                return View();

			}
		}

        //--------------------Register--------------------------


		public IActionResult customerRegister()
		{
			return View();
		}

        [HttpPost]
		public IActionResult customerRegister(Customer customer)
		{
            _Context.tbl_customer.Add(customer);
            _Context.SaveChanges();
			return RedirectToAction("customerLogin");
		}


        //-----------------------------Logout---------------------------

        public IActionResult customerLogout()
        {
            HttpContext.Session.Remove("customerSession");
            return RedirectToAction("index");
        }

        public IActionResult CustomerProfile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");

            }
            else
            {
                List<Category> category = _Context.tbl_category.ToList();
                ViewData["category"] = category;
                var customerId = HttpContext.Session.GetString("customerSession");
                var row = _Context.tbl_customer.Where(c => c.customer_Id == int.Parse(customerId)).ToList();
                return View(row);

               
            }
        }

        //------------------------Update Customer-------------------------------

        [HttpPost]
        public IActionResult updateCustomerProfile(Customer customer)
        {
            _Context.tbl_customer.Update(customer);
            _Context.SaveChanges();
            return RedirectToAction("CustomerProfile");
        }

        public IActionResult updateCustomerimage(Customer customer, IFormFile customer_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "customer_images", customer_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            customer_image.CopyTo(fs);
            customer.customer_image = customer_image.FileName;
            _Context.tbl_customer.Update(customer);
            _Context.SaveChanges();
            return RedirectToAction("CustomerProfile");
        }


        //----------------------------------Contact Us---------------------------


        public IActionResult feedback()
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;
            return View();
        }

        [HttpPost]
        public IActionResult feedback(Feedback feedback)
        {
            TempData["massage"]= "Thank you your feedback";
            _Context.tbl_feedback.Add(feedback);
            _Context.SaveChanges();
            return RedirectToAction("feedback");
        }

        //------------------------Product------------------------------

        public IActionResult fetchAllProducts()
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

            List<Product> products = _Context.tbl_product.ToList();
            ViewData["product"] = products;
            return View();
        }
        public IActionResult ProductDetail(int id)
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

           var products = _Context.tbl_product.Where(p => p.product_id == id).ToList();

            return View(products);
        }




        //-----------------------------------------Cart------------------------------------




        public IActionResult AddToCart(int prod_id, Cart cart)
        {
            string isLogin = HttpContext.Session.GetString("customerSession");

            if (isLogin != null)
            {
                cart.prod_id = prod_id;
                cart.cust_id = int.Parse(isLogin);
                cart.product_quntity = 1;
                cart.cart_status = 0;

                _Context.tbl_cart.Add(cart);
                _Context.SaveChanges();

                TempData["message"] = "Product Successfully Added to Cart";
                return RedirectToAction("fetchAllProducts");
               
            }
            else
            {
                return RedirectToAction("customerLogin");
            }
        }

        public IActionResult fetchCart()
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

            string customerId = HttpContext.Session.GetString("customerSession");

            if (customerId != null)
            {
                var cart = _Context.tbl_cart.Where(c=>c.cust_id == int.Parse(customerId)).Include(c=>c.products).ToList();
                return View(cart);
            }
            else
            {
                return RedirectToAction("customerLogin");
            }
        }

        public IActionResult removeProduct(int id)
        {
            var product = _Context.tbl_cart.Find(id);
            _Context.tbl_cart.Remove(product);
            _Context.SaveChanges();
            return RedirectToAction("fetchCart");
        }


        public IActionResult AboutUs()
        {
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

            return View();

        }





    }
}
