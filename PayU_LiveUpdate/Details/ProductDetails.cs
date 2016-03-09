using PayU_Core;
using PayU_LiveUpdate.Enums;

namespace PayU_LiveUpdate
{
   

    public sealed class ProductDetails : PayU_Core.Base.ProductDetails
    {
        public ProductDetails()
        {
            PriceType = PriceType.NET;
            Code = "";
            Name = "";
            Information = "";
        }

        [Parameter(Name = "ORDER_VAT", SortIndex = 46)]
        public decimal VAT { get; set; }

        [Parameter(Name = "ORDER_PRICE_TYPE", SortIndex = 115)]
        public PriceType PriceType { get; set; }
    }

}

