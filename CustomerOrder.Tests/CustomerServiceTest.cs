using CustomerOrder.Domain.Dto;
using CustomerOrder.Domain.Interface;
using CustomerOrder.Domain.Model;
using CustomerOrderAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CustomerOrder.Tests
{
    public class CustomerServiceTest
    {
        private IServiceProvider _serviceProvider;
        public Mock<ICustomerService> MockCustomerRepo { get; set; } = new Mock<ICustomerService>();
        public Mock<CustomerToAddDto> customerToAdd { get; set; } = new Mock<CustomerToAddDto>();


        [SetUp]
        public void Setup()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var mockServiceProvider = new Mock<IServiceProvider>(MockBehavior.Strict);
            mockServiceProvider.Setup(p => p.GetService(typeof(ICustomerService))).Returns(MockCustomerRepo.Object).Verifiable();
            _serviceProvider = mockServiceProvider.Object;
        }

        [Test]
        public async Task TestAddACustomer()
        {
            //arrange
            var userToAdd = new CustomerController(_serviceProvider);
            MockAddCustomer(201);
            var expected = 201;
            var newUser = new CustomerToAddDto
            {
                Name = "John Doe",
                Age = 19,
                Gender = 1,
                Address = {},
                Orders = {}
            };

            //act
            var actualResult = await userToAdd.AddNewCustomer(newUser) as OkObjectResult;

            //assert
            Assert.AreEqual(expected, actualResult.StatusCode);
        }

        [Test]
        public async Task TestUpdateACustomer()
        {
            //arrange
            //act
            //assert
            Assert.Pass();
        }

        [Test]
        public async Task TestDeleteACustomer()
        {
            //arrange
            //act
            //assert
            Assert.Pass();
        }

        private void MockEntityStatusCodeToReturn(int state)
        {
            MockCustomerRepo.Setup(u => u.GetCustomerByCustomerId(It.IsAny<string>()))
                            .Returns(Task.FromResult(new ResponseDto<CustomerToReturnDto> { StatusCode = state }));
        }

        private void MockAddCustomer(int state)
        {
            MockCustomerRepo.Setup(u => u.AddCustomer(It.IsAny<CustomerToAddDto>()))
                            .Returns(Task.FromResult(new ResponseDto<CustomerToReturnDto> { StatusCode = state }));
        }
    }
}