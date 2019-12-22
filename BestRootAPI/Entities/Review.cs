using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Review : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string ReviewComment { get; set; }
        [Required]
        public int Stars { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
