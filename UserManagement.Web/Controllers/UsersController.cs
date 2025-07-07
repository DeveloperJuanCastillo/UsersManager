using Microsoft.AspNetCore.Mvc;
using UserManagement.Web.Models;

namespace UserManagement.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/users");
            return View(usuarios);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _httpClient.PostAsJsonAsync("api/users", model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(int id)
        {
            var usuarios = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/users");
            var usuario = usuarios?.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UserViewModel model)
        {
            await _httpClient.PutAsJsonAsync($"api/users/{model.Id}", model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _httpClient.DeleteAsync($"api/users/{id}");
            return RedirectToAction("Index");
        }
    }
}
