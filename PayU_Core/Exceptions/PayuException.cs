using System;

namespace PayU_Core.Exceptions
{
    public class PayuException: ApplicationException
    {
        public PayuException (string message, Exception innerException): base(message, innerException)
        {
        }
    }
}

