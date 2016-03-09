﻿using System.Collections.Generic;
using PayU_Core;
using PayU_LiveUpdate.Enums;

namespace PayU_LiveUpdate
{

    public sealed class OrderDetails : PayU_Core.Base.OrderDetails
    {
        public OrderDetails()
        {
            ProductDetails = new List<ProductDetails>();
            DestinationCity = "";
            DestinationState = "";
            DestinationCountry = "";
            InstallmentOptions = "";
        }

        [Parameter(Name = "LU_ENABLE_TOKEN", SortIndex = 15, ExcludeFromHash = true)]
        public bool? TokenEnable { get; set; }

        [Parameter(Name = "LU_TOKEN_TYPE", SortIndex = 16, ExcludeFromHash = true)]
        public PayU_Core.Base.TokenType? TokenType { get; set; }

        [Parameter(Name = "BACK_REF", ExcludeFromHash = true)]
        public string ReturnUrl { get; set; }

        [Parameter(Name = "ORDER_SHIPPING", SortIndex = 50)]
        public decimal ShippingCosts { get; set; }

        [Parameter(IsNested = true)]
        public IList<ProductDetails> ProductDetails { get; set; }

        [Parameter(Name = "DISCOUNT", SortIndex = 70)]
        public decimal? Discount { get; set; }

        [Parameter(Name = "DESTINATION_CITY", SortIndex = 80)]
        public string DestinationCity { get; set; }

        [Parameter(Name = "DESTINATION_STATE", SortIndex = 90)]
        public string DestinationState { get; set; }

        [Parameter(Name = "DESTINATION_COUNTRY", SortIndex = 100)]
        public string DestinationCountry { get; set; }

        [Parameter(Name = "INSTALLMENT_OPTIONS", SortIndex = 120)]
        public string InstallmentOptions { get; set; }

        [Parameter(IsNested = true, ExcludeFromHash = true)]
        public BillingDetails BillingDetails { get; set; }

        [Parameter(IsNested = true, ExcludeFromHash = true)]
        public DeliveryDetails DeliveryDetails { get; set; }

        /* Additional parameters */
        [Parameter(Name = "TESTORDER", ExcludeFromHash = true)]
        public bool? TestOrder { get; set; }

        [Parameter(Name = "DEBUG", ExcludeFromHash = true)]
        public bool? Debug { get; set; }

        [Parameter(Name = "LANGUAGE", ExcludeFromHash = true)]
        public Language? Language { get; set; }

        [Parameter(Name = "AUTOMODE", ExcludeFromHash = true)]
        public bool? AutoMode { get; set; }

        [Parameter(Name = "ORDER_TIMEOUT", ExcludeFromHash = true)]
        public int? OrderTimeout { get; set; }

        [Parameter(Name = "TIMEOUT_URL", ExcludeFromHash = true)]
        public string TimeoutURL { get; set; }
    }
}

