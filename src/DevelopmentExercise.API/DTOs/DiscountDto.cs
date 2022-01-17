namespace DevelopmentExercise.API.DTOs
{
    public class DiscountDto
    {
        public int ID { get; set; }
        public string DiscountDescription { get; set; } = null!;
        public decimal Value { get; set; }
        public bool Percentage { get; set; }
    }
}