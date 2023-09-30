using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages
{
    public class NotFoundModel : PageModel
    {
        [BindProperty]
        public CustomerBase? Customer { get; set; }

        public void OnGet()
        {
        }
    }
}
