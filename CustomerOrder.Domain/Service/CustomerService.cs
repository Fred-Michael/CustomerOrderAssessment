using CustomerOrder.Domain.Dto;
using CustomerOrder.Domain.Interface;
using CustomerOrder.Domain.ManualMapper;
using CustomerOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Domain.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseDto<CustomerToReturnDto>> AddCustomer(CustomerToAddDto customer)
        {
            ResponseDto<CustomerToReturnDto> response = new ResponseDto<CustomerToReturnDto>();
            if(customer == null)
            {
                response.Errors.Add("Customer", "Cannot add an empty customer");
                response.Message = "A customer must be provided";
                response.StatusCode = 400;
                return response;
            }

            Customer customerToAdd = CustomerMapper.MapAddCustomerToCustomer(customer);
            var customerAdded = await _customerRepository.AddCustomer(customerToAdd);
            bool result = await _customerRepository.Completed();
            if(!result)
            {
                response.Errors.Add("Customer", "Could not add customer");
                response.Message = "A customer could not be added";
                response.StatusCode = 400;
            }
            else
            {
                response.Message = "A customer was successfully added";
                response.StatusCode = 201;
                response.IsSuccess = true;
                response.Data = CustomerMapper.MapCustomerToCustomerToBeReturned(customerAdded);
            }

            return response;
        }

        public async Task<ResponseDto<string>> DeleteCustomer(string id)
        {
            ResponseDto<string> response = new ResponseDto<string>();
            if (string.IsNullOrWhiteSpace(id))
            {
                response.Errors.Add("id", "Id must be provided");
                response.Message = "Empty id supplied";
                response.StatusCode = 400;
                return response;
            }

            var customer = await _customerRepository.GetCustomerByCustomerId(id);
            if(customer is null)
            {
                response.Errors.Add("Customer", "Invalid id provided");
                response.Message = "Customer does not exist";
                response.StatusCode = 404;
                return response;
            }

            _customerRepository.DeleteCustomer(customer);
            bool result = await _customerRepository.Completed();

            if (!result)
            {
                response.Errors.Add("Customer", "Could not delete customer");
                response.Message = "Customer was not deleted";
                response.StatusCode = 400;
            }
            else
            {
                response.Message = "Customer successfully deleted";
                response.StatusCode = 200;
                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<ResponseDto<IEnumerable<CustomerToReturnDto>>> GetAllCustomers()
        {
            var customer = await _customerRepository.GetCustomers();

            List<CustomerToReturnDto> customerToReturned = new List<CustomerToReturnDto>();

            foreach(var item in customer)
            {
                var result = CustomerMapper.MapCustomerToCustomerToBeReturned(item);
                customerToReturned.Add(result);
            }

            var response = new ResponseDto<IEnumerable<CustomerToReturnDto>>
            {
                Message = $"Details of all customer retrieved",
                StatusCode = 200,
                IsSuccess = true,
                Data = customerToReturned,
            };

            return response;
        }

        public async Task<ResponseDto<CustomerToReturnDto>> GetCustomerByCustomerId(string id)
        {
            ResponseDto<CustomerToReturnDto> response = new ResponseDto<CustomerToReturnDto>();

            if (string.IsNullOrWhiteSpace(id))
            {
                response.Errors.Add("id", "Id must be provided");
                response.Message = "Empty id supplied";
                response.StatusCode = 400;
                return response;
            }

            var customer = await _customerRepository.GetCustomerByCustomerId(id);
            if (customer is null)
            {
                response.Errors.Add("Customer", "Invalid id provided");
                response.Message = "Customer does not exist";
                response.StatusCode = 404;
                return response;
            }
            else
            {
                response.Message = $"Customer with id {id} was successfully retrieved";
                response.StatusCode = 200;
                response.IsSuccess = true;
                response.Data = CustomerMapper.MapCustomerToCustomerToBeReturned(customer);
            }

            return response;
        }

        public async Task<ResponseDto<CustomerToReturnDto>> GetCustomerByCustomerName(string name)
        {
            ResponseDto<CustomerToReturnDto> response = new ResponseDto<CustomerToReturnDto>();

            if (string.IsNullOrWhiteSpace(name))
            {
                response.Errors.Add("name", "Name must be provided");
                response.Message = "Name cannot be null";
                response.StatusCode = 400;
                return response;
            }

            var customer = await _customerRepository.GetCustomerByCustomerName(name);
            if (customer is null)
            {
                response.Errors.Add("Customer", "Invalid id provided");
                response.Message = "Customer does not exist";
                response.StatusCode = 404;
                return response;
            }
            else
            {
                response.Message = $"Customer with name {name} was successfully retrieved";
                response.StatusCode = 200;
                response.IsSuccess = true;
                response.Data = CustomerMapper.MapCustomerToCustomerToBeReturned(customer);
            }

            return response;
        }

        public async Task<ResponseDto<string>> UpdateCustomer(CustomerToUpdateDto customer)
        {
            ResponseDto<string> response = new ResponseDto<string>();

            if (customer is null)
            {
                response.Errors.Add("Customer", "Customer must be provided");
                response.Message = "Empty customer supplied";
                response.StatusCode = 400;
                return response;
            }

            var customerToUpdate = CustomerMapper.MapUpdateCustomerToCustomer(customer);
            _customerRepository.UpdateCustomer(customerToUpdate);
            bool result = await _customerRepository.Completed();

            if (!result)
            {
                response.Errors.Add("Customer", "Could not update customer");
                response.Message = "Customer was not updated";
                response.StatusCode = 400;
            }
            else
            {
                response.Message = "Customer successfully updated";
                response.StatusCode = 200;
                response.IsSuccess = true;
            }

            return response;
        }
    }
}
