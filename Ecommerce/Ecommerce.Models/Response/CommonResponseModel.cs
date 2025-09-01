using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Response
{
    public class CommonResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public dynamic Result { get; set; }
    }
}
