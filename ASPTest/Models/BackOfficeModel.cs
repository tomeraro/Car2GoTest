using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTest.Models
{
    public class BackOfficeModel
    {
        public List<Tuple<int, int>> ItemsAndCount { get; set; }
        public List<Tuple<int, int>> ItemsAndCountFromDate { get; set; }

    }
}