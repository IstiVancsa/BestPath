using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

}
