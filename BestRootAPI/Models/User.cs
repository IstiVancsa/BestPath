using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : BaseModel
    {
        public Guid Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public override IList<BaseModel> CreateSeeds(int numberOfSeeds)
        {
            //TODO implement a function to generate numberOfSeeds models
            return null;
        }
    }
}
