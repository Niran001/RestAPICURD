using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICrud.Models
{
    public class FunctionResponse
    {
        public string status { get; set; }
        public object result { get; set; }
        public string message { get; set; }
    }
}
