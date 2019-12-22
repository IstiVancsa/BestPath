using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entities
{
    public class User : BaseEntity
    {
        public Guid Token { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required] 
        public int Age { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
