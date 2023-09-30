using CustomerApp.Models;
using CustomerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages.Customer
{
    public class AddCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public AddCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [BindProperty]
        public CustomerBase? Customer { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var res = await _customerService.AddCustomerAsync(Customer);

            if (res)
                return RedirectToPage("./List");
            else
                return Page();
        }
    }
}
