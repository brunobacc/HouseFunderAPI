using Microsoft.EntityFrameworkCore;

namespace housefunder.Models
{
    [Keyless]
    public class ProjectsFinanced
    {
        public int project_id { get; set; }
        public string location { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double total_financed { get; set; }
        public double final_value { get; set; }
        public double total_financed_user { get; set; }
    }
}
