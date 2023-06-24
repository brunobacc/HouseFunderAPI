using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace housefunder.Models
{
    [Keyless]
    public class EditUsersImage
    {
        public string image { get; set; }

        public EditUsersImage(string image)
        {
            this.image = image;
        }
    }
}
