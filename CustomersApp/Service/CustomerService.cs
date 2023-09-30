using CustomerApp.Models;
using Newtonsoft.Json;

namespace CustomerApp.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CustomerBase?>> GetAllCustomerAsync()
        {
            var custdata = await _httpClient.GetStringAsync("Customers");
            if (custdata == null)
            {
                return Enumerable.Empty<CustomerBase?>();
            }
            return JsonConvert.DeserializeObject<IEnumerable<CustomerBase?>>(custdata);
        }

        public async Task<bool> AddCustomerAsync(CustomerBase? customer)
        {
            var customerData = new CustomerBase()
            {
                Id = customer!.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Email = customer.Email,
                Phone_Number = customer.Phone_Number,
                Country_code = customer.Country_code,
                Gender = customer.Gender,
                Balance = customer.Balance,
            };
            var bodyContent = JsonContent.Create(customerData);
            var response = await _httpClient.PostAsync("Customer", bodyContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            if (customerId == null)
            {
                return false;
            }
            var response = await _httpClient.DeleteAsync("Customer/" + customerId);
            return response.IsSuccessStatusCode;
        }

        public async Task<CustomerBase?> GetCustomerById(string customerId)
        {
            if (customerId == null)
            {
                return null!;
            }
            var response = await _httpClient.GetStringAsync("Customer/" + customerId);
            return JsonConvert.DeserializeObject<CustomerBase?>(response); ;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerBase updatedcustomer)
        {
            CustomerBase? customer = JsonConvert.DeserializeObject<CustomerBase>(await _httpClient.GetStringAsync("Customer/" + updatedcustomer.Id));
            if (customer == null)
            {
                return false;
            }
            if(customer.Id==updatedcustomer.Id && customer.Firstname == updatedcustomer.Firstname && customer.Lastname == updatedcustomer.Lastname && 
                customer.Email == updatedcustomer.Email && customer.Phone_Number == updatedcustomer.Phone_Number && customer.Country_code == updatedcustomer.Country_code && 
                customer.Gender == updatedcustomer.Gender && customer.Balance == updatedcustomer.Balance)
            { return false; }
            customer!.Firstname = updatedcustomer.Firstname;
            customer!.Lastname = updatedcustomer.Lastname;
            customer!.Email = updatedcustomer.Email;
            customer!.Phone_Number = updatedcustomer.Phone_Number;
            customer!.Country_code = updatedcustomer.Country_code;
            customer!.Gender = updatedcustomer.Gender;
            customer!.Balance = updatedcustomer.Balance;
            var bodyContent = JsonContent.Create(customer);
            var response = await _httpClient.PostAsync("Customer/" + customer!.Id, bodyContent);
            return response.IsSuccessStatusCode;
        }
    }
}
