using DevelopmentExercise.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopmentExercise.API.Data
{
    public class SeedData :
          IEntityTypeConfiguration<User>
        , IEntityTypeConfiguration<Discount>
        , IEntityTypeConfiguration<Order>
    {

        private readonly List<User> _users;
        private readonly List<Discount> _discounts;
        private readonly List<Order> _orders;

        public SeedData()
        {
            _users = new List<User>
            {
                new User
                    {
                        ID = 1,
                        FirstName = "Metin",
                        LastName = "TASLIK",
                        RoleID = 1,
                        Role = Role.Employee,
                        Created = DateTime.Now.AddYears(-5),
                        Email = "metinn.taslik@gmail.com"
                    },
                    new User
                    {
                        ID = 2,
                        FirstName = "Metin",
                        LastName = "TASLIK",
                        RoleID = 3,
                        Role = Role.Customer,
                        Created = DateTime.Now.AddYears(-4),
                        Email = "metinn.taslik@outlook.com"
                    },
                    new User
                    {
                        ID = 3,
                        FirstName = "Demo",
                        LastName = "DEMO",
                        RoleID = 2,
                        Role = Role.Affiliate,
                        Created = DateTime.Now.AddMonths(-6),
                        Email = "demo@demo.com"
                    },
                    new User
                    {
                        ID = 4,
                        FirstName = "Test",
                        LastName = "TEST",
                        RoleID = 3,
                        Role = Role.Customer,
                        Created = DateTime.Now.AddDays(-7),
                        Email = "test@test.com"
                    }
            };
            _discounts = new List<Discount>
            {
                new Discount
                {
                    ID = 1,
                    DiscountDescription = "For an employee of the store, gets a 30% discount",
                    Value = 0.3m,
                    RoleID = (int)Role.Employee,
                    Percentage = true
                },
                new Discount
                {
                    ID = 2,
                    DiscountDescription = "For an affiliate of the store, gets a 10% discount",
                    Value = 0.1m,
                    RoleID = (int)Role.Affiliate,
                    Percentage = true
                },
                    new Discount
                    {
                        ID = 3,
                        DiscountDescription = "Customer for over 2 years, gets a 5% discount",
                        Value = 0.5m,
                        RoleID = (int)Role.Customer,
                        Percentage = true
                    },
                    new Discount
                    {
                        ID = 4,
                        DiscountDescription = "For every $100 on the bill, there would be a $ 5 discount",
                        Value = 5,
                        Percentage = false
                    }
            };
            _orders = new List<Order>
            {
                new Order
                {
                    ID = 1,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 1,
                    OrderCost = 36778.74m,
                    QuantityCount = 1,
                    Created = DateTime.Now
                },
                new Order
                {
                    ID = 2,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 2,
                    OrderCost = 10980.00m,
                    QuantityCount = 1,
                    Created = DateTime.Now
                },
                new Order
                {
                    ID = 3,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 3,
                    QuantityCount = 2,
                    OrderCost = 950.00m,
                    Created = DateTime.Now
                },
                new Order
                {
                    ID = 4,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 4,
                    QuantityCount = 1,
                    OrderCost = 600.75m,
                    Created = DateTime.Now
                },
                new Order
                {
                    ID = 5,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 2,
                    QuantityCount = 1,
                    OrderCost= 4999.00m,
                    Created = DateTime.Now,
                },
                new Order
                {
                    ID = 6,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 1,
                    QuantityCount = 1,
                    OrderCost= 17999.00m,
                    Created = DateTime.Now,
                },
                new Order
                {
                    ID = 7,
                    OrderNumber = DataHelper.RandomString(8),
                    UserID = 4,
                    QuantityCount = 1,
                    OrderCost= 99.99m,
                    Created = DateTime.Now
                },
            };
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(_users);
        }

        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(_discounts);
        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(_orders);
        }
    }
}