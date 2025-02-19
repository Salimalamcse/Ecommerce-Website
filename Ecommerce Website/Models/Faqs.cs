using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Website.Models
{
    public class Faqs
    {
        [Key]
        public int faq_Id { get; set; }

        public string fqs_question { get; set; }

        public string fqs_answer { get; set; }


    }
}
