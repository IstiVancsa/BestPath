using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review:BaseModel
    {
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
    }
}
