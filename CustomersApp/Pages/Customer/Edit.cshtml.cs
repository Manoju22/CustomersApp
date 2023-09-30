using CustomerApp.Models;
using CustomerApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages.Customer
{
    public class EditCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditCustomerModel(ICustomerService customerService)
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
            if (!ModelState.IsValid)
                return Page();
            var res = await _customerService.UpdateCustomerAsync(Customer!);

            if (res)
                return RedirectToPage("./List");
            else
                ModelState.AddModelError("NoChange", "There is no change in exsisting data. Please update atleast one field.");
            return Page();
        }
    }
}
