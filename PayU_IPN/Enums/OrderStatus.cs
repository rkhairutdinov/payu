using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayU_IPN.Enums
{
    public enum OrderStatus
    {
        [XmlEnum("PAYMENT_AUTHORIZED")]
        PaymentAuthorized,
        [XmlEnum("PAYMENT_RECEIVED")]
        PaymentReceived,
        [XmlEnum("TEST")]
        Test,
        [XmlEnum("CASH")]
        Cash,
        [XmlEnum("COMPLETE")]
        Complete,
        [XmlEnum("REVERSED")]
        Reversed,
        [XmlEnum("REFUND")]
        Refund
    }
}
