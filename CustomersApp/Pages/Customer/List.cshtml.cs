using CustomerApp.Models;
using CustomerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages.Customer
{
    public class ListUsersModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public ListUsersModel(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public IEnumerable<CustomerBase?> CustomersData;
        public async Task OnGetAsync()
        {
            CustomersData = await _customerService.GetAllCustomerAsync();
        }
    }
}
