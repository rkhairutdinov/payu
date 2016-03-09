using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayU_Core;

namespace PayU_ALU.Details
{
    public class ProductDetails : PayU_Core.Base.ProductDetails
    {
        [Parameter(Name = "ORDER_VER")]
        public string Version { get; set; }
    }
}
