using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace housefunder.Models
{
    [Keyless]
    public class Partnerships
    {
        public string name { get; set; }
        public string image { get; set; }
        public string validated_proposals { get; set; }
    }
}
