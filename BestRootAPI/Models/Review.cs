using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review:BaseModel
    {
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public override IList<BaseModel> CreateSeeds(int numberOfSeeds)
        {
            //TODO implement a function to generate numberOfSeeds models
            return null;
        }
    }
}
