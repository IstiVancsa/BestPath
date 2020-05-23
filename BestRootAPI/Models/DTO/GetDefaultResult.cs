using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class GetDefaultResult<T> : BaseTokenizedDTO
    {
        public List<T> Items { get; set; }
    }
}
