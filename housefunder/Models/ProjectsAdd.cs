using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class ProjectsAdd
    {
        public int status_id { get; set; }
        public int category_id { get; set; }
        public int partnership_id { get; set; }
        public int financer_id { get; set; }
        public string location { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string final_value { get; set; }
    }
}
