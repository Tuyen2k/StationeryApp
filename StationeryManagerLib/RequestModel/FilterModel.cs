using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class FilterModel
    {
        //public string? Id { get; set; } = "";
        public string? Name { get; set; } = "";
        public int? Limit { get; set; } = 10;
        public int? Page { get; set; } = 0;
    }
}
