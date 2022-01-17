using AutoMapper;
using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.DTOs;
using DevelopmentExercise.API.Models;

namespace DevelopmentExercise.API.Core.Repositories
{
    public class RepositoryInvoice : IRepositoryInvoice
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<Invoice> _invoiceRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public RepositoryInvoice
            (
                IBaseRepository<User> userRepository,
                IBaseRepository<Order> orderRepository,
                IBaseRepository<Invoice> invoiceRepository,
                IDiscountRepository discountRepository,
                IMapper mapper
            )
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _invoiceRepository = invoiceRepository;
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<GenerateInvoiceDto>> GetGenerateInvoiceAsync(int orderID)
        {
            Order? order = (await _orderRepository.GetAsync(x => x.ID == orderID).ConfigureAwait(false)).FirstOrDefault();
            if (order is null)
                return new ResponseModel<GenerateInvoiceDto>(true, (int)ErrorType.OrderNotFound, ErrorType.OrderNotFound.ToString());

            User? user = (await _userRepository.GetAsync(x => x.ID == order.UserID).ConfigureAwait(false)).FirstOrDefault();
            if (user is null)
                return new ResponseModel<GenerateInvoiceDto>(true, (int)ErrorType.UserNotFound, ErrorType.UserNotFound.ToString());

            order.User = user;
            Invoice? invoice = (await _invoiceRepository.GetAsync(x => x.OrderID == orderID).ConfigureAwait(false)).FirstOrDefault();
            if (invoice is not null)
                return new ResponseModel<GenerateInvoiceDto>(true, (int)ErrorType.InvoiceAlreadyCreated, ErrorType.InvoiceAlreadyCreated.ToString());

            order.DiscountCost = await _discountRepository.GetDiscountCalculationAsync(orderID).ConfigureAwait(false);
            order.TotalCost = order.OrderCost - order.DiscountCost;
            invoice = new Invoice
            {
                OrderID = orderID,
                Created = DateTime.Now,
                InvoiceNumber = Data.DataHelper.RandomString(8),
                Order = order,
                InvoiceTotalPrice = order.TotalCost
            };
            await _invoiceRepository.CreateAsync(invoice).ConfigureAwait(false);

            return new ResponseModel<GenerateInvoiceDto>(model: _mapper.Map<GenerateInvoiceDto>(invoice));
        }
    }
}