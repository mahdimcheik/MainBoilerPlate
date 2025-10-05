using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(UsersService usersService) : ControllerBase
    {
        [HttpGet("list")]
        public async Task<ActionResult<ResponseDTO<List<UserResponseDTO>>>> GetAllUsers()
        {
            var users = await usersService.GetUsers();
            return Ok(new ResponseDTO<List<UserResponseDTO>>
            {
                Message = "All users",
                Status = StatusCodes.Status200OK,
                Data = users
            });
        }
    }
}
