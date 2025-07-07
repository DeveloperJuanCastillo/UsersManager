using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Web.Models;

namespace UserManagement.Web.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<UserViewModel> Users { get; set; } = new();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var result = await client.GetFromJsonAsync<List<UserViewModel>>("api/users");
            if (result != null)
                Users = result;
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            await client.DeleteAsync($"api/users/{id}");
            return RedirectToPage();
        }
    }
}
