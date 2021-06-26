using CustomerOrder.Domain.Dto;
using CustomerOrder.Domain.Enum;
using CustomerOrder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Domain.ManualMapper
{
    public static class CustomerMapper
    {
        public static Customer MapAddCustomerToCustomer(CustomerToAddDto customer)
        {
            List<Order> orders = new List<Order>();
            foreach(var item in customer.Orders)
            {
                var orderToAdd = new Order
                {
                    OrderDate = DateTime.Parse(item.OrderDate),
                    Amount = item.Amount
                };

                orders.Add(orderToAdd);
            }

            return new Customer
            {
                Name = customer.Name,
                Age = customer.Age,
                Gender =  (Gender)customer.Gender,
                Address = new Address
                {
                    Street = customer.Address.Street,
                    Postcode = customer.Address.Postcode,
                    HouseNumber = customer.Address.HouseNumber
                },
                Orders = orders
            };
        }

        public static Customer MapUpdateCustomerToCustomer(CustomerToUpdateDto customer)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in customer.Orders)
            {
                var orderToAdd = new Order
                {
                    OrderId = item.OrderId,
                    OrderDate = DateTime.Parse(item.OrderDate),
                    Amount = item.Amount
                };

                orders.Add(orderToAdd);
            }

            return new Customer
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Age = customer.Age,
                Gender = (Gender)customer.Gender,
                Address = new Address
                {
                    AddressId = customer.Address.AddressId,
                    Street = customer.Address.Street,
                    Postcode = customer.Address.Postcode,
                    HouseNumber = customer.Address.HouseNumber
                },
                Orders = orders
            };
        }

        public static CustomerToReturnDto MapCustomerToCustomerToBeReturned(Customer customer)
        {
            List<OrderToReturnDto> orders = new List<OrderToReturnDto>();
            foreach (var item in customer.Orders)
            {
                var orderToAdd = new OrderToReturnDto
                {
                    OrderId = item.OrderId,
                    OrderDate = item.OrderDate.ToString(),
                    Amount = item.Amount
                };

                orders.Add(orderToAdd);
            }

            return new CustomerToReturnDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Age = customer.Age,
                Gender = customer.Gender.ToString(),
                Address = new AddressToReturnDto
                {
                    AddressId = customer.Address.AddressId,
                    Street = customer.Address.Street,
                    Postcode = customer.Address.Postcode,
                    HouseNumber = customer.Address.HouseNumber
                },
                Orders = orders
            };
        }
    }
}
