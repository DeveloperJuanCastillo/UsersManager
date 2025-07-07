using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.Repositories;

namespace UserManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UsersController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new UserRepository(connectionString);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _repository.AddUser(user);
            return Ok(new { message = "Usuario creado correctamente" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            user.Id = id;
            _repository.UpdateUser(user);
            return Ok(new { message = "Usuario actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteUser(id);
            return Ok(new { message = "Usuario eliminado correctamente" });
        }
    }
}
