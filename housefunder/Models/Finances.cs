using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    public class Finances
    {
        public int financer_id { get; set; }
        public int project_id { get; set; }
        public double financed_value { get; set; }
        public DateTime financed_date { get; set; }

        public Finances(int financer_id, int project_id, double financed_value, DateTime financed_date)
        {
            this.financer_id = financer_id;
            this.project_id = project_id;
            this.financed_value = financed_value; 
            this.financed_date = financed_date;
        }
    }
}
