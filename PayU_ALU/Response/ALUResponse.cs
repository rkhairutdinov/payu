using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace PayU_ALU
{
    [XmlRoot(ROOT_ELEMENT_NAME)]
    public class ALUResponse
    {
        private const string ROOT_ELEMENT_NAME = "EPAYMENT";

        [XmlElement("REFNO")]
        public string RefNo { get; set; }

        [XmlElement("ALIAS")]
        public string Alias { get; set; }

        [XmlElement("STATUS")]
        public Status Status { get; set; }

        [XmlElement("RETURN_CODE")]
        public string ReturnCode { get; set; }

        [XmlElement("RETURN_MESSAGE")]
        public string ReturnMessage { get; set; }

        [XmlElement("DATE")]
        public string Date { get; set; }

        [XmlElement("CURRENCY")]
        public string Currency { get; set; }

        [XmlElement("INSTALLMENTS_NO")]
        public string InstallmentNumber { get; set; }

        [XmlElement("CARD_PROGRAM_NAME")]
        public string CardProgramName { get; set; }

        [XmlElement("URL_3DS")]
        public string Url3DS { get; set; }

        [XmlElement("AMOUNT")]
        public decimal? Amount { get; set; }

        [XmlElement("ORDER_REF")]
        public string OrderRef { get; set; }

        [XmlElement("HASH")]
        public string Hash { get; set; }

        /* ALU v2 fields */

        [XmlElement("AUTH_CODE")]
        public string AuthCode { get; set; }

        [XmlElement("RRN")]
        public string RRN { get; set; }

        [XmlElement("RESPONSE")]
        public string BankResponse { get; set; }

        [XmlElement("PROCRETURNCODE")]
        public string BankReturnCode { get; set; }

        [XmlElement("TRANSID")]
        public string TransactionId { get; set; }

        [XmlElement("ERRORMESSAGE")]
        public string BankErrorMessage { get; set; }

        [XmlElement("CLIENTID")]
        public string BankClientId { get; set; }

        [XmlElement("OID")]
        public string BankOrderId { get; set; }

        [XmlElement("MDSTATUS")]
        public string BankMDStatus { get; set; }

        [XmlElement("MDERRORMSG")]
        public string BankMDErrorMessage { get; set; }

        [XmlElement("TXSTATUS")]
        public string BankTransactionStatus { get; set; }

        [XmlElement("ECI")]
        public string ECI { get; set; }

        [XmlElement("XID")]
        public string XID { get; set; }

        [XmlElement("CAVV")]
        public string CAVV { get; set; }

        [XmlElement("PAN")]
        public string PAN { get; set; }

        [XmlElement("EXPYEAR")]
        public string ExpiryYear { get; set; }

        [XmlElement("EXPMONTH")]
        public string ExpiryMonth { get; set; }

        /*  ALU v3 fields */
        [XmlArray("WIRE_ACCOUNTS")]
        [XmlArrayItem("ITEM", typeof(WireAccount))]
        public WireAccount[] WireAccounts { get; set; }

        [XmlElement("TOKEN_HASH")]
        public string TokenHash { get; set; }

        public bool IsSuccess
        {
            get { return Status == Status.Success; }
        }

        public bool Is3DSResponse
        {
            get
            {
                return (ReturnCode == ReturnCodes.ThreeDSEnrolled &&
                Url3DS != null &&
                Url3DS != string.Empty);
            }
        }

        public static ALUResponse FromString(string response)
        {
            // Make sure there is no preceeding/trailing whitespace in the XML response.
            response = response.Trim();

            using (var stringReader = new StringReader(response))
            {
                return new XmlSerializer(typeof(ALUResponse)).Deserialize(stringReader) as ALUResponse;
            }
        }

        public static ALUResponse FromHttpRequest(HttpRequest request)
        {
            var xmlStr = ConvertRequestFormToXml(request);
            return FromString(xmlStr);
        }

        private static string ConvertRequestFormToXml(HttpRequest request)
        {
            StringBuilder xml = new StringBuilder();
            using (var writer = XmlWriter.Create(xml))
            {
                writer.WriteStartElement(ROOT_ELEMENT_NAME);
                foreach (var key in request.Form.AllKeys)
                {
                    writer.WriteStartElement(key);
                    writer.WriteString(request.Form[key]);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            return xml.ToString();
        }
    }
}
