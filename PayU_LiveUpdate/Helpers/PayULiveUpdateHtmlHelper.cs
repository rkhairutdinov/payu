using System.Web.Mvc;
namespace PayU_LiveUpdate.Helpers
{
   public static class PayULiveUpdateHtmlHelper
    {
       public static string LuPaymentForm(this HtmlHelper helper, OrderDetails order, string key,string buttonName, string formId,
           string target = null)
       {
           var service = new LiveUpdateService(key);

           return service.RenderPaymentForm(order, formId, buttonName, target);
       }
    }
}
