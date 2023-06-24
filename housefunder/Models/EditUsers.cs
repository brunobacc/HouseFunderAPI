using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    [Keyless]
    public class EditUsers
    {
        public string username { get; set; }
        public string email { get; set; }
        public string? password { get; set; }

        public EditUsers(string username, string email, string? password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
