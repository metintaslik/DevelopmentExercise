namespace DevelopmentExercise.API.DTOs
{
    public class InvoiceOrderDto
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public decimal OrderCost { get; set; }
        public decimal DiscountCost { get; set; } = 0.00m;
    }
}