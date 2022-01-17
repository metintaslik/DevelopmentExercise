using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.Data;
using DevelopmentExercise.API.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevelopmentExercise.Test
{
    public class BaseRepositoryTest
    {
        private readonly Mock<IBaseRepository<User>> _baseRepositoryMock = new();

        [Fact]
        public void Base_Test()
        {
            List<User> users = new()
            {
                new User
                {
                    ID = 1,
                    Created = DateTime.Now,
                    FirstName = "Metin",
                    LastName = "TASLIK",
                    RoleID = (int)Role.Employee,
                    Email = "metinn.taslik@gmail.com"
                },
                new User
                {
                    ID = 2,
                    Created = DateTime.Now,
                    FirstName = "Demo",
                    LastName = "DEMO",
                    RoleID = (int)Role.Affiliate,
                    Email = "demo@gmail.com"
                },
                new User
                {
                    ID = 3,
                    Created = DateTime.Now,
                    FirstName = "Test",
                    LastName = "TEST",
                    RoleID = (int)Role.Customer,
                    Email = "test@gmail.com"
                }
            };

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseInMemoryDatabase("Exercise.db")
                                .Options;

            using var context = new ApplicationContext(options);
            var userRepository = new BaseRepository<User>(context);
            userRepository.CreateAsync(users[0]).ConfigureAwait(false).GetAwaiter().GetResult();
            userRepository.CreateAsync(users[1]).ConfigureAwait(false).GetAwaiter().GetResult();
            userRepository.CreateAsync(users[2]).ConfigureAwait(false).GetAwaiter().GetResult();

            var userCollection = userRepository.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var firstUser = userRepository.GetAsync(x => x.ID == users[0].ID).ConfigureAwait(false).GetAwaiter().GetResult().FirstOrDefault();

            Assert.NotEmpty(userCollection);
            Assert.NotNull(firstUser);
            Assert.Equal(firstUser, userCollection.FirstOrDefault(x => x.ID == users[0].ID));
            Assert.IsType<User>(firstUser);
            Assert.Equal(userCollection.Count(), users.Count);
            Assert.True(firstUser != null);
        }

        [Fact]
        public void Base_Mock_Test()
        {
            List<User> users = new()
            {
                new User
                {
                    Created = DateTime.Now,
                    FirstName = "Metin",
                    LastName = "TASLIK",
                    RoleID = (int)Role.Employee,
                    Email = "metinn.taslik@gmail.com"
                },
                new User
                {
                    Created = DateTime.Now,
                    FirstName = "Demo",
                    LastName = "DEMO",
                    RoleID = (int)Role.Affiliate,
                    Email = "demo@gmail.com"
                },
                new User
                {
                    Created = DateTime.Now,
                    FirstName = "Test",
                    LastName = "TEST",
                    RoleID = (int)Role.Customer,
                    Email = "test@gmail.com"
                },
            };


            _baseRepositoryMock.Setup(x => x.CreateAsync(users[0])).Verifiable();
            _baseRepositoryMock.Setup(x => x.CreateAsync(users[1])).Verifiable();
            _baseRepositoryMock.Setup(x => x.CreateAsync(users[2])).Verifiable();
            _baseRepositoryMock.Setup(x => x.GetAsync(x => x.ID == users[0].ID)).ReturnsAsync(users);

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                               .UseInMemoryDatabase("Exercise.db")
                               .Options;
            using var context = new ApplicationContext(options);
            var service = new BaseRepository<User>(context);
            service.CreateAsync(users[0]).ConfigureAwait(false).GetAwaiter().GetResult();
            service.CreateAsync(users[1]).ConfigureAwait(false).GetAwaiter().GetResult();
            service.CreateAsync(users[2]).ConfigureAwait(false).GetAwaiter().GetResult();
            var user = service.GetAsync(x => x.ID == users[0].ID).ConfigureAwait(false).GetAwaiter().GetResult().FirstOrDefault()!;

            Assert.NotEmpty(users);
            Assert.NotNull(user);
            Assert.IsType<User>(user);
            Assert.Equal(user, users[0]!);
        }
    }
}