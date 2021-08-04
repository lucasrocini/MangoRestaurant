using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web
{
    public static class SD //SD = Static Details
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
