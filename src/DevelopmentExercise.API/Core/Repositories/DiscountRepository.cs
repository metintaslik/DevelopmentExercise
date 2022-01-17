using AutoMapper;
using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.DTOs;
using DevelopmentExercise.API.Models;

namespace DevelopmentExercise.API.Core.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Discount> _discountRepository;
        private readonly IMapper _mapper;

        public DiscountRepository
            (
                IBaseRepository<Order> orderRepository,
                IBaseRepository<User> userRepository,
                IBaseRepository<Discount> discountRepository,
                IMapper mapper
            )
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<decimal> GetDiscountCalculationAsync(int orderID)
        {
            Order? order = (await _orderRepository.GetAsync(x => x.ID == orderID).ConfigureAwait(false)).FirstOrDefault();
            if (order is null)
                return 0;

            User? user = (await _userRepository.GetAsync(x => x.ID == order.UserID).ConfigureAwait(false)).FirstOrDefault();
            if (user is null)
                return 0;

            List<Discount> discounts = (await _discountRepository.GetAsync().ConfigureAwait(false))!.ToList();
            if (discounts.Count > 0)
            {
                order.User = user;
                order.DiscountCost = 0;
                if (order.OrderCost > 100)
                    order.DiscountCost += Math.Floor(order.OrderCost / 100) * discounts.FirstOrDefault(x => !x.Percentage)!.Value;

                var discount = discounts.FirstOrDefault(x => x.RoleID == order.User.RoleID);
                if (discount != null && (discount.RoleID == 3 && order.User.Created <= DateTime.Now.AddYears(-2)))
                    order.DiscountCost += order.OrderCost * discount.Value;
            }

            order.TotalCost = order.OrderCost - order.DiscountCost;
            await _orderRepository.UpdateAsync(order).ConfigureAwait(false);

            return order.DiscountCost;
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountsAsync() => _mapper.Map<IEnumerable<DiscountDto>>(await _discountRepository.GetAsync().ConfigureAwait(false));
    }
}