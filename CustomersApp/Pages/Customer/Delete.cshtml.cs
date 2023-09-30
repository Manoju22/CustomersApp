using CustomerApp.Models;
using CustomerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [BindProperty]
        public CustomerBase? Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Customer = await _customerService.GetCustomerById(id);
            if (Customer == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerService.DeleteCustomerAsync(Customer!.Id!);
            return RedirectToPage("./List");
        }
    }
}
