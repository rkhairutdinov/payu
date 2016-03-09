namespace PayU_ALU
{
    public static class ReturnCodes
    {
        public static readonly string Authorized = "AUTHORIZED";
        public static readonly string ThreeDSEnrolled = "3DS_ENROLLED";
        public static readonly string AlreadyAuthorized = "ALREADY_AUTHORIZED";
        public static readonly string AuthorizationFailed = "AUTHORIZATION_FAILED";
        public static readonly string InvalidCustomerInfo = "INVALID_CUSTOMER_INFO";
        public static readonly string InvalidPaymentInfo = "INVALID_PAYMENT_INFO";
        public static readonly string InvalidAccount = "INVALID_ACCOUNT";
        public static readonly string InvalidPaymentMethodCode = "INVALID_PAYMENT_METHOD_CODE";
        public static readonly string InvalidCurrency = "INVALID_CURRENCY";
        public static readonly string RequestExpired = "REQUEST_EXPIRED";
        public static readonly string HashMismatch = "HASH_MISMATCH";
        public static readonly string WrongVersion = "WRONG_VERSION";
        public static readonly string InvalidCCToken = "INVALID_CC_TOKEN";
    }
}