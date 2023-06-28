using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    [Keyless]
    public class Administrator
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public int validated_proposals { get; set; }
    }
}
