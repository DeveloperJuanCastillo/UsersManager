using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Web.Models;

namespace UserManagement.Web.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UpdateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public UserViewModel Usuario { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var users = await client.GetFromJsonAsync<List<UserViewModel>>("api/users");
            var user = users?.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            Usuario = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _httpClientFactory.CreateClient("ApiClient");
            await client.PutAsJsonAsync($"api/users/{Usuario.Id}", Usuario);

            return RedirectToPage("Index");
        }
    }
}
