using AcortURL.Entities;
using AcortURL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace AcortURL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userService;
        public UserController(UserServices userRepository)
        {
            _userService = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
                return Ok(_userService.GetAll());

        }
        
        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            User? user = _userService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            var dto = new GetUserByIdDto()
            {
                
                UserName = user.Username,
                Id = user.Id,
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            if (!_userService.CheckIfUserExists(userId))
            {
                return NotFound();
            }
            try
            {
                _userService.Update(dto, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            User? user = _userService.GetById(id);
            if (user is null)
            {
                return BadRequest("El cliente que intenta eliminar no existe");
            }
                _userService.Delete(id);
            return NoContent();
        }
    }
}
