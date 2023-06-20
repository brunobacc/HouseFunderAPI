using Microsoft.EntityFrameworkCore;

namespace housefunder.Models
{
    [Keyless]
    public class ProjectsFinanced
    {
        public String title { get; set; }
        public String image { get; set; }
        public double total_financed { get; set; }
    }
}
