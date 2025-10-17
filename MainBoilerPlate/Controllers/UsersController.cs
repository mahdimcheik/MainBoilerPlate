using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(UsersService usersService) : ControllerBase
    {
        [HttpPost("list")]
        public async Task<ActionResult<ResponseDTO<List<UserResponseDTO>>>> GetAllUsers([FromBody] DynamicFilters<UserApp> tableState)
        {
            var users = await usersService.GetUsers(tableState);
            return Ok(users);
        }
    }
}
