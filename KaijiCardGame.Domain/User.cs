using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaijiCardGame.Domain
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
