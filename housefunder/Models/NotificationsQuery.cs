using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    [Keyless]
    public class NotificationsQuery
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
