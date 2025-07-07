using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Web.Models;

namespace UserManagement.Web.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public UserViewModel User { get; set; } = new();

        public void OnGet()
        {
            User.Birthdate = DateTime.Today.AddYears(-18);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _httpClientFactory.CreateClient("ApiClient");
            await client.PostAsJsonAsync("api/users", User);

            return RedirectToPage("Index");
        }
    }
}
