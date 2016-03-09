using System;

namespace PayU_Core.Base
{
    public class ProductDetails
    {

        [Parameter(Name = "ORDER_PNAME", SortIndex = 41)]
        public string Name { get; set; }

        [Parameter(Name = "ORDER_PCODE", SortIndex = 42)]
        public string Code { get; set; }

        [Parameter(Name = "ORDER_PRICE", SortIndex = 44)]
        public decimal UnitPrice { get; set; }

        [Parameter(Name = "ORDER_QTY", SortIndex = 45)]
        public int Quantity { get; set; }

        #region Optional

        [Parameter(Name = "ORDER_PINFO", SortIndex = 43)]
        public string Information { get; set; }

        #endregion
    }
}

