﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PayU_Core;

namespace PayU_IPN
{
    public class IPNService
    {
        public string SignatureKey { get; private set; }

        public IPNService(string signatureKey)
        {
            if (string.IsNullOrEmpty(signatureKey))
                throw new InvalidOperationException("Необходимо указать секретный ключ.");
            this.SignatureKey = signatureKey;
        }

        public IPNRequest ParseRequest(string response)
        {
            response = response.Trim();

            using (var stringReader = new StringReader(response))
            {
                return new XmlSerializer(typeof(IPNRequest)).Deserialize(stringReader) as IPNRequest;
            }
        }

        public IPNRequest ParseRequest(System.Web.HttpRequest request)
        {
            return ParseRequest(request.Form);
        }

        public IPNRequest ParseRequest(NameValueCollection parameters)
        {
            var xmlStr = IPNRequest.ConvertRequestFormToXml(parameters);
            return ParseRequest(xmlStr);
        }

        private static void AppendToHashString(StringBuilder sb, object data)
        {
            var str = data.ToString();
            sb.Append(Encoding.UTF8.GetByteCount(str));
            sb.Append(str);
        }

        public string GenerateResponseForRequest(IPNRequest request)
        {
            var hash = string.Empty;
            var now = DateTime.Now.ToString("yyyyMMddHHmmss");
            var hashStr = new StringBuilder();

            if (request.Products.Length > 0)
            {
                AppendToHashString(hashStr, request.Products[0].Id);
                AppendToHashString(hashStr, request.Products[0].Name);
                AppendToHashString(hashStr, request.Date);
                AppendToHashString(hashStr, now);

                hash = hashStr.ToString().HashWithSignature(SignatureKey);
            }

            return string.Format("<{0}>{1}|{2}</{0}>", IPNRequest.ROOT_ELEMENT_NAME, now, hash);
        }
    }
}
