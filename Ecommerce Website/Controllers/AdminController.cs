using Ecommerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Include this namespace for LINQ operations

namespace Ecommerce_Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly myContext _context;
        private IWebHostEnvironment _env;

        public AdminController(myContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        //-----------------------------Login----------------------------------------------------------------

        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");

            if (admin_session != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public IActionResult Login()
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Login(string adminEmail, string adminPassword) 
        {
            var admin = _context.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail);
            if (admin != null && admin.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session", admin.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect Username or Password"; 
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }


        //---------------------------Profile--------------------------------------------


        //public IActionResult Profile()
        //{

        //    var adminId = HttpContext.Session.GetString("admin_session");
        //    var row = _context.tbl_admin.Where(a => a.admin_id == int.Parse(adminId)).ToList();
        //    return View(row);

        //}


        public IActionResult Profile()
        {
            var adminId = HttpContext.Session.GetString("admin_session");

            if (string.IsNullOrEmpty(adminId))
            {
                return RedirectToAction("Login"); // Session NULL ho to Login par bhej do
            }

            if (!int.TryParse(adminId, out int adminIdInt))
            {
                return BadRequest("Invalid Admin ID");
            }

            var row = _context.tbl_admin.Where(a => a.admin_id == adminIdInt).ToList();

            if (!row.Any())
            {
                return NotFound("Admin not found");
            }

            return View(row);
        }

        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile admin_image,Admin admin)
        {
            string ImagePath = Path.Combine(_env.WebRootPath,"admin_image",admin_image.FileName);
            FileStream fs = new FileStream(ImagePath,FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image = admin_image.FileName;
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }

        //----------------------Customer------------------------------------


        public IActionResult Customer()
        {
            return View(_context.tbl_customer.ToList());
        }

        public IActionResult CustomerDetails(int id)
        {
           
            return View(_context.tbl_customer.FirstOrDefault(c => c.customer_Id == id));
            
        }


        public IActionResult updateCustomer(int id)
        {
            return View(_context.tbl_customer.Find(id));
        }

        [HttpPost]
        public IActionResult updateCustomer(Customer customer,IFormFile customer_image)
        {
           
            String ImagePath = Path.Combine(_env.WebRootPath, "customer_images",customer_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            customer_image.CopyTo(fs);
            customer.customer_image = customer_image.FileName;
            _context.tbl_customer.Update(customer);
            _context.SaveChanges(); 
            return RedirectToAction("Customer");
        }

        public IActionResult deletePermission(int id)
        {
            return View(_context.tbl_customer.FirstOrDefault(c => c.customer_Id == id));

        }

        public IActionResult deleteCustomer(int id)
        {
            var customer = _context.tbl_customer.Find(id);
            _context.tbl_customer.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Customer");
        }

        //------------------------------Cotetegory--------------------------------------------------------------

        public IActionResult fetchCategory()
        {
            return View(_context.tbl_category.ToList());
        }

        public IActionResult addCategory(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult addCategory(Category cat)
        {
            _context.tbl_category.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }

        public IActionResult updateCategory(int id)
        {
            var category = _context.tbl_category.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult updateCategory(Category cat)
        {
            _context.tbl_category.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }

        public IActionResult deletePermissionCategory(int id)
        {
            return View(_context.tbl_category.FirstOrDefault(c => c.category_id == id));

        }

        public IActionResult deleteCategory(int id)
        {
            var customer = _context.tbl_category.Find(id);
            _context.tbl_category.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }

        //-------------------------Product------------------------------------------------------------------------

        public IActionResult fetchProduct()
        {
            return View(_context.tbl_product.ToList());
        }

        public IActionResult addProduct()
        {
            List<Category> categories = _context.tbl_category.ToList();
            ViewData["category"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult addProduct(Product prod, IFormFile product_image)
        {
            string imageName = Path.GetFileName(product_image.FileName);
            string imagePath = Path.Combine(_env.WebRootPath, "product_images", imageName);
            FileStream fs = new FileStream(imagePath,FileMode.Create);
            product_image.CopyTo(fs);
            prod.product_image = imageName;

            _context.tbl_product.Add(prod);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult ProductDetails(int id)
        {

            return View(_context.tbl_product
                .Include(p=>p.Category)
                .FirstOrDefault(c => c.product_id == id));

        }

        public IActionResult deletePermissionProduct(int id)
        { 
            return View(_context.tbl_product.FirstOrDefault(c => c.product_id == id));
        }

        public IActionResult deleteProduct(int id)
        {
            var product = _context.tbl_product.Find(id);
            _context.tbl_product.Remove(product);
            _context.SaveChanges();
            return View(product);
        }

        public IActionResult updateProduct(int id)
        {
            List<Category> categories = _context.tbl_category.ToList();
            ViewData["category"] = categories;

            var product = _context.tbl_product.Find(id);
            ViewBag.selectedCategoryId = product.cat_id;
            return View(product);
        }
        [HttpPost]
        public IActionResult updateProduct(Product product)
        {
            _context.tbl_product.Update(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }

        [HttpPost]
        public IActionResult ChangeProductImage(Product product,IFormFile product_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "product_images", product_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            product_image.CopyTo(fs);
            product.product_image = product_image.FileName;
            _context.tbl_product.Update(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }

        public IActionResult fetchfeedback()
        {
            var row = _context.tbl_feedback.ToList();
            return View(row); 
        }
        public IActionResult deletePermissionfeedback(int id)
        {
            return View(_context.tbl_feedback.FirstOrDefault(f => f.feedback_id == id));
        }

        public IActionResult deletefeedback(int id)
        {
            var feedback = _context.tbl_feedback.Find(id);
            _context.tbl_feedback.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("fetchfeedback");
        }

        //--------------------------------------Cart--------------------------------------

        public IActionResult fetchCart()
        {
            var cart = _context.tbl_cart.Include(c => c.products).Include(c => c.customers).ToList();

            return View(cart);
        }

        public IActionResult deletePermissionCart(int id)
        {
            return View(_context.tbl_cart.FirstOrDefault(c => c.Id == id));
        }

        public IActionResult deleteCart(int id)
        {
            var Cart = _context.tbl_cart.Find(id);
            _context.tbl_cart.Remove(Cart);
            _context.SaveChanges();
            return RedirectToAction("fetchCart");
        }

        public IActionResult updateCart(int id)
        {
            var cart = _context.tbl_cart.Find(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult updateCart(int cart_status, Cart cart)
        {
            _context.tbl_cart.Update(cart);
            _context.SaveChanges();
            return RedirectToAction("fetchCart");
        }


    }
}
