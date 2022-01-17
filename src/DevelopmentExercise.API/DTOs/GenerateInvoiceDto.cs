namespace DevelopmentExercise.API.DTOs
{
    public class GenerateInvoiceDto
    {
        public int ID { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public decimal InvoiceTotalPrice { get; set; }
        public DateTime Created { get; set; }
        public InvoiceOrderDto Order { get; set; } = null!;
    }
}
