namespace Api.Schema.Request
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public string CVC { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}
