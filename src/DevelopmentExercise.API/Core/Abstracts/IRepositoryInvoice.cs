using DevelopmentExercise.API.DTOs;
using DevelopmentExercise.API.Models;

namespace DevelopmentExercise.API.Core.Abstracts
{
    public interface IRepositoryInvoice
    {
        Task<ResponseModel<GenerateInvoiceDto>> GetGenerateInvoiceAsync(int orderID);
    }
}