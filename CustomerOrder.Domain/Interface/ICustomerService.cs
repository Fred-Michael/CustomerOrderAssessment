using CustomerOrder.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Domain.Interface
{
    public interface ICustomerService
    {
        Task<ResponseDto<IEnumerable<CustomerToReturnDto>>> GetAllCustomers();
        Task<ResponseDto<CustomerToReturnDto>> GetCustomerByCustomerId(string id);
        Task<ResponseDto<CustomerToReturnDto>> GetCustomerByCustomerName(string name);
        Task<ResponseDto<CustomerToReturnDto>> AddCustomer(CustomerToAddDto customer);
        Task<ResponseDto<string>> UpdateCustomer(CustomerToUpdateDto customer);
        Task<ResponseDto<string>> DeleteCustomer(string id);
    }
}
