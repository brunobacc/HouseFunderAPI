using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    [Keyless]
    public class FinancersQuery
    {
        public string username { get; set; }
        public string image { get; set; }
    }
}
