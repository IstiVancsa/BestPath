using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review:BaseModel
    {
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public Guid UserId { get; set; }

        public override BaseEntity GetEntity()
        {
            return new Entities.Review
            {
                Id = this.Id,
                ReviewComment = this.ReviewComment,
                Stars = this.Stars,
                UserId = this.UserId
            };
        }
    }
}
