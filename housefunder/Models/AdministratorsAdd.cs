using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    public class AdministratorAdd
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
