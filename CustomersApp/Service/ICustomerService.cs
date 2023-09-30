using CustomerApp.Models;

namespace CustomerApp.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerBase?>> GetAllCustomerAsync();

        Task<bool> AddCustomerAsync(CustomerBase? customer);

        Task<bool> DeleteCustomerAsync(string customerId);

        Task<CustomerBase?> GetCustomerById(string customerId);

        Task<bool> UpdateCustomerAsync(CustomerBase customer);
    }
}
