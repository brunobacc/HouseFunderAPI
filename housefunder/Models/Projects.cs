using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class Projects
    {
        [Key] public int project_id { get; set; }
        public int status_id { get; set; }
        public int category_id { get; set; }
        public int partnership_id { get; set; }
        public string location { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double total_financed { get; set; }
        public double final_value { get; set; }
        public int total_investor { get; set; }
        public DateTime date_created { get; set; }

        public Projects(int project_id, int status_id, int category_id, int partnership_id, string location, string image, string title, string description, double total_financed, double final_value, int total_investor, DateTime date_created)
        {
            this.project_id = project_id;
            this.status_id = status_id;
            this.category_id = category_id;
            this.partnership_id = partnership_id;
            this.location = location;
            this.image = image;
            this.title = title;
            this.description = description;
            this.total_financed = total_financed;
            this.final_value = final_value;
            this.total_investor = total_investor;
            this.date_created = date_created;
        }
    }
}
