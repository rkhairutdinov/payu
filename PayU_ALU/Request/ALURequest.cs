using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PayU_Core.Exceptions;

namespace PayU_ALU
{
    internal class ALURequest
    {
        private ALURequest()
        {
        }

        public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
                                          SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string SendRequest(ALUService service, NameValueCollection requestData)
        {
            var webClient = new WebClient();

            try
            {
                if (service.IgnoreSSLCertificate)
                {
                    ServicePointManager.ServerCertificateValidationCallback = Validator;
                }
                return Encoding.UTF8.GetString(webClient.UploadValues(service.EndpointUrl, requestData));
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                }
                throw new PayuException(string.Format("Request to url {0} failed with status {1} and response {2}", (object)service.EndpointUrl, (object)ex.Status, (object)ex.Response), ex);
            }
            catch (Exception ex)
            {
                throw new PayuException("An exception occured during ALU request", ex);
            }
        }
    }
}
