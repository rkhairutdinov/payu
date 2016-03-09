﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayU_Core;
using PayU_Core.Base;

namespace PayU_ALU.Details
{
    public class OrderDetails : PayU_Core.Base.OrderDetails
    {
        public OrderDetails()
        {
            ProductDetails = new List<ProductDetails>();
        }

        [Parameter(Name = "LU_ENABLE_TOKEN", SortIndex = 15)]
        public bool? TokenEnable { get; set; }

        [Parameter(Name = "LU_TOKEN_TYPE", SortIndex = 16)]
        public PayU_Core.Base.TokenType? TokenType { get; set; }

        [Parameter(IsNested = true)]
        public IList<ProductDetails> ProductDetails { get; set; }

        [Parameter(IsNested = true)]
        public BillingDetails BillingDetails { get; set; }

        [Parameter(IsNested = true)]
        public CardDetails CardDetails { get; set; }

        [Parameter(IsNested = true)]
        public DeliveryDetails DeliveryDetails { get; set; }

        [Parameter(Name = "BACK_REF")]
        public string ReturnUrl { get; set; }

        /* Optional Parameters */

        [Parameter(Name = "CLIENT_IP")]
        public string ClientIpAddress { get; set; }

        [Parameter(Name = "CLIENT_TIME", FormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ClientTime { get; set; }

        [Parameter(Name = "SELECTED_INSTALLMENTS_NUMBER")]
        public int? SelectedInstallmentNumber { get; set; }

        [Parameter(Name = "CARD_PROGRAM_NAME")]
        public string CardProgramName { get; set; }

        [Parameter(Name = "ORDER_TIMEOUT")]
        public int? OrderTimeout { get; set; }

        [Parameter(Name = "USE_LOYALTY_POINTS", FormatString = "{0:YES;NO;NO}")]
        public bool? UseLoyaltyPoints { get; set; }

        [Parameter(Name = "LOYALTY_POINTS_AMOUNT")]
        public decimal? LoyaltyPointsAmount { get; set; }

        [Parameter(Name = "CAMPAIGN_TYPE")]
        public CampaignType CampaignType { get; set; }

        [Parameter(Name = "ORDER_SHIPPING")]
        public decimal? ShippingCost { get; set; }
    }
}
