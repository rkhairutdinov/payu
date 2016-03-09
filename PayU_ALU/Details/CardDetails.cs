using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayU_Core;

namespace PayU_ALU.Details
{
    public class CardDetails
    {
        [Parameter(Name = "CC_NUMBER")]
        public string CardNumber { get; set; }

        [Parameter(Name = "EXP_MONTH")]
        public string ExpiryMonth { get; set; }

        [Parameter(Name = "EXP_YEAR")]
        public string ExpiryYear { get; set; }

        [Parameter(Name = "CC_TYPE")]
        public string CardType { get; set; }

        [Parameter(Name = "CC_CVV")]
        public string CVV { get; set; }

        [Parameter(Name = "CC_OWNER")]
        public string CardOwnerName { get; set; }

        [Parameter(Name = "CC_TOKEN")]
        public string Token { get; set; }
    }
}
