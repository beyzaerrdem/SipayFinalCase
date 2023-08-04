namespace Api.Schema.Response
{
    public class InvoiceResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }
    }
}
