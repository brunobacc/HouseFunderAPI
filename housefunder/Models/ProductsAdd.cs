using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class ProductsAdd
    {
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int? value { get; set; }
    }
}
