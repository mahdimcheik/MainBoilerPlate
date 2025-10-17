using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    public class UsersService(MainContext context)
    {
        public async Task<ResponseDTO<List<UserResponseDTO>>> GetUsers(DynamicFilters<UserApp> tableState)
        {
            var query = context.Users
                .Include(x => x.Languages)
                .Include(x => x.Status)
                .Include(x => x.Gender)
                .Include(x => x.Experiences)
                .Include(x => x.Formations)
                .Include(x => x.TeacherCursuses)
                .Include(x => x.UserRoles) // ✅ Now we can include UserRoles
                .AsQueryable();

            if (!string.IsNullOrEmpty(tableState.Search))
            {
                query = query.Where(u => string.Concat(u.FirstName.ToLower(), " ", u.LastName.ToLower()).Contains(tableState.Search.ToLower()));
            }

            // Apply filters, sorting, and pagination
            var countValues = await query.ApplyAndCountAsync(tableState);

            // Now get role names from the included UserRoles and join with Roles table
            var userIds = countValues.Values.Select(u => u.Id).ToList();
            var userRolesDict = await context.UserRoles
                .Where(ur => userIds.Contains(ur.UserId))
                .Join(context.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => new { ur.UserId, RoleName = r.Name })
                .GroupBy(x => x.UserId)
                .ToDictionaryAsync(
                    g => g.Key,
                    g => g.Select(x => x.RoleName ?? string.Empty).ToList()
                );

            return new ResponseDTO<List<UserResponseDTO>>
            {
                Status = 200,
                Message = "Utilisateurs récupérés avec succès",
                Data = countValues.Values.Select(x => new UserResponseDTO(
                    x,
                    userRolesDict.ContainsKey(x.Id) ? userRolesDict[x.Id] : new List<string>()
                )).ToList(),
                Count = countValues.Count
            };
        }
    }
}
