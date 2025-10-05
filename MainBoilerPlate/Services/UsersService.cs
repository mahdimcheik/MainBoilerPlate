using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    public class UsersService(MainContext context)
    {
        public async Task<List<UserResponseDTO>> GetUsers()
        {
            var query = (IQueryable<UserApp>)context.Users;

            return await query.Select(u => new UserResponseDTO(u, null)).ToListAsync();
        }
    }
}
