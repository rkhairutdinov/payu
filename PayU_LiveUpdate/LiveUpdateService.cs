using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using PayU_Core;
namespace PayU_LiveUpdate
{
  public class LiveUpdateService
  {
    private readonly string DefaultEndpoint = "https://secure.payu.ru/order/lu.php";

    public string SignatureKey { get; private set; }
    public string EndpointUrl { get; private set; }

    public LiveUpdateService(string signatureKey, string endpointUrl = null)
    {
      if (string.IsNullOrEmpty(signatureKey))
        throw new InvalidOperationException("Небходимо указать Секретный ключ");
      this.SignatureKey = signatureKey;
      this.EndpointUrl = string.IsNullOrEmpty(endpointUrl) ? DefaultEndpoint : endpointUrl;
    }

    public string RenderPaymentForm(OrderDetails order, string buttonName)
    {
      return RenderPaymentForm(order, buttonName, "payForm");
    }

    public string RenderPaymentForm(OrderDetails order, string formId, string buttonName, string target=null)
    {
      var sb = new StringBuilder();

      sb.AppendFormat(@"<form action=""{0}"" method=""POST"" id=""{1}"" name=""{2}"">", EndpointUrl, formId, formId);
      sb.AppendLine();
      sb.Append(RenderPaymentInputs(order));
      sb.AppendFormat(@"<input type=""submit""  value=""{0}"" target=""{1}"">", buttonName,target);
      sb.AppendLine();
      sb.AppendLine("</form>");

      return sb.ToString();
    }

    public string RenderPaymentInputs(OrderDetails order) {
        var parameterHandler = new ParameterHandler(order, false);
      parameterHandler.CreateOrderRequestHash(this.SignatureKey);
      var requestData = parameterHandler.GetRequestData();

      var sb = new StringBuilder();

      foreach (var key in requestData.AllKeys) {
        sb.AppendFormat(@"<input type=""hidden"" name=""{0}"" value=""{1}"">", key, requestData[key]);
        sb.AppendLine();
      }

      return sb.ToString();
    }

    public NameValueCollection GetValuesAsDictionary(OrderDetails order)
    {
        var parameterHandler = new ParameterHandler(order, false);
        parameterHandler.CreateOrderRequestHash(this.SignatureKey);
        return  parameterHandler.GetRequestData();
    }


    public bool VerifyControlSignature (System.Web.HttpRequest request)
    {
      var ctrl = request.QueryString["ctrl"];

      if (string.IsNullOrEmpty(ctrl)) {
        return false;
      }

      var url = request.Url.ToString().Replace("&ctrl=" + ctrl, "").Replace("?ctrl=" + ctrl, "");

      var hashString = url.Length.ToString() + url;
      var hash = hashString.HashWithSignature(this.SignatureKey);

      return hash == ctrl.ToLowerInvariant();
    }
  }
}
