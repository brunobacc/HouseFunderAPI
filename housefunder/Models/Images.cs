using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class Images
    {
        [Key]public int id { get; set; }
        public string imagepath { get; set; }
        public DateTime insertedon { get; set; }
    }
}
