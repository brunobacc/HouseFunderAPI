using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    public class Products
    {
        [Key] public int product_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public double? value { get; set; }

        public Products(int product_id, string title, string description, int price, string image, double? value)
        {
            this.product_id = product_id;
            this.title = title;
            this.description = description; 
            this.price = price;
            this.image = image;
            this.value = value;
        }
    }
}
