using DevelopmentExercise.API.DTOs;

namespace DevelopmentExercise.API.Core.Abstracts
{
    public interface IDiscountRepository
    {
        Task<decimal> GetDiscountCalculationAsync(int orderID);
        Task<IEnumerable<DiscountDto>> GetDiscountsAsync();
    }
}