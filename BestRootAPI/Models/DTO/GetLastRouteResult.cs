using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.DTO
{
    public class GetLastRouteResult : BaseTokenizedDTO
    {
        public List<Tuple<DateTime, List<City>>> Cities { get; set; }
    }
}
