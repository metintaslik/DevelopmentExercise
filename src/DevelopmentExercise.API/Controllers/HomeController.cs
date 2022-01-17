using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.DTOs;
using DevelopmentExercise.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentExercise.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IRepositoryInvoice _repositoryInvoice;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public HomeController(IDiscountRepository discountRepository, IRepositoryInvoice repositoryInvoice, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _discountRepository = discountRepository;
            _repositoryInvoice = repositoryInvoice;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet("GetDiscounts")]
        public async Task<IActionResult> GetDiscountsAsync()
        {
            return Ok(await _discountRepository.GetDiscountsAsync().ConfigureAwait(false));
        }

        [HttpPatch("GetCalculationDiscount")]
        public async Task<IActionResult> GetCalculationDiscount([FromQuery] int orderID)
        {
            ResponseModel<object> response = new();
            await _unitOfWorkRepository.TransactionAsync().ConfigureAwait(false);
            response.Model = await _discountRepository.GetDiscountCalculationAsync(orderID).ConfigureAwait(false);
            await _unitOfWorkRepository.CommitAsync().ConfigureAwait(false);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetCreateInvoice([FromQuery] int orderID)
        {
            await _unitOfWorkRepository.TransactionAsync().ConfigureAwait(false);
            ResponseModel<GenerateInvoiceDto> response = await _repositoryInvoice.GetGenerateInvoiceAsync(orderID).ConfigureAwait(false);
            await _unitOfWorkRepository.CommitAsync().ConfigureAwait(false);
            return Ok(response);
        }
    }
}