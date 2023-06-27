using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    public class Notifications
    {
        [Key] public int notification_id { get; set; }
        public int financer_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public Notifications(string title, string description) 
        {
            this.title = title;
            this.description = description;
        }
    }
}
