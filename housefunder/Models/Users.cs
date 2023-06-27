using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class Users
    {
        [Key] public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string image { get; set; }
        public DateTime registration_date { get; set; }
        public int permission_level { get; set; }
        public int validated_proposals { get; set; }
        public int active_projects { get; set; }
        public int finished_projects { get; set; }
        public int financing_done { get; set; }
        public double total_amount_financed { get; set; }
        public int accepted_projects { get; set; }
        public int points { get; set; }

        public Users(string username, string email, string password, int permission_level)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.permission_level = permission_level;
            image = "user_image.jpg";
            registration_date = DateTime.Now;
        }
    }
}
