using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    public class UsersService(MainContext context)
    {
        public async Task<ResponseDTO< List<UserResponseDTO>>> GetUsers(DynamicFilters<UserApp> tableState)
        {
            var query = (IQueryable<UserApp>)context.Users
                .Include(x => x.Languages)
                .Include(x => x.Status)
                .Include(x => x.Gender)
                .Include(x => x.Experiences)
                .Include(x => x.Formations)
                .Include(x => x.TeacherCursuses);

            if(!string.IsNullOrEmpty(tableState.Search))
            {
                query = query.Where(u => string.Concat( u.FirstName.ToLower(), " ", u.LastName.ToLower()).Contains(tableState.Search.ToLower()));
            }

            var countValues = await query.ApplyAndCountAsync(tableState);

            return new ResponseDTO<List<UserResponseDTO>>
            {
                Status = 200,
                Message = "Cursus récupérés avec succès",
                Data = countValues.Values.Select(x => new UserResponseDTO(x, null)).ToList(),
                Count = countValues.Count
            };

            //return await query.Select(u => new UserResponseDTO(u, null)).ToListAsync();
        }
    }
}
