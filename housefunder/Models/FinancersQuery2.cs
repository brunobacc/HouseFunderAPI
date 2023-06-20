using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    [Keyless]
    public class FinancersQuery2
    {
        public string username { get; set; }
        public string image { get; set; }
        public int financingDone { get; set; }
        public double totalAmountFinanced { get; set; }
    }
}
