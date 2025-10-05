using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly MainContext context;

        public GendersController(MainContext context)
        {
            this.context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ResponseDTO<List<GenderDTO>>>> GetAllGenders()
        {
            var genders = await context.Genders
                .AsNoTracking()
                .Select(g => new GenderDTO(g)).ToListAsync();
            return Ok(new ResponseDTO<List<GenderDTO>>
            {
                Message = "All genders",
                Status = StatusCodes.Status200OK,
                Data = genders
            });
        }
    }
}
