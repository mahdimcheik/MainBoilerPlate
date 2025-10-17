using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des rôles d'application
    /// </summary>
    public class RoleAppService(MainContext context, RoleManager<RoleApp> roleManager)
    {
        /// <summary>
        /// Récupère tous les rôles
        /// </summary>
        /// <returns>Liste des rôles</returns>
        public async Task<ResponseDTO<List<RoleAppResponseDTO>>> GetAllRolesAsync()
        {
            try
            {
                var roles = await context.Roles
                    .AsNoTracking()
                    .Where(r => r.ArchivedAt == null)
                    .OrderBy(r => r.Name)
                    .Select(r => new RoleAppResponseDTO(r))
                    .ToListAsync();

                return new ResponseDTO<List<RoleAppResponseDTO>>
                {
                    Status = 200,
                    Message = "Rôles récupérés avec succès",
                    Data = roles,
                    Count = roles.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<RoleAppResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des rôles: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un rôle par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du rôle</param>
        /// <returns>Rôle trouvé</returns>
        public async Task<ResponseDTO<RoleAppResponseDTO>> GetRoleByIdAsync(Guid id)
        {
            try
            {
                var role = await context.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id && r.ArchivedAt == null);

                if (role == null)
                {
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 404,
                        Message = "Rôle non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 200,
                    Message = "Rôle récupéré avec succès",
                    Data = new RoleAppResponseDTO(role)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du rôle: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un rôle par son nom
        /// </summary>
        /// <param name="name">Nom du rôle</param>
        /// <returns>Rôle trouvé</returns>
        public async Task<ResponseDTO<RoleAppResponseDTO>> GetRoleByNameAsync(string name)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(name);

                if (role == null || role.ArchivedAt != null)
                {
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 404,
                        Message = "Rôle non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 200,
                    Message = "Rôle récupéré avec succès",
                    Data = new RoleAppResponseDTO(role)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du rôle: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée un nouveau rôle
        /// </summary>
        /// <param name="roleDto">Données du rôle à créer</param>
        /// <returns>Rôle créé</returns>
        public async Task<ResponseDTO<RoleAppResponseDTO>> CreateRoleAsync(RoleAppCreateDTO roleDto)
        {
            try
            {
                // Vérifier que le nom n'existe pas déjà
                var existingRole = await roleManager.FindByNameAsync(roleDto.Name);
                if (existingRole != null && existingRole.ArchivedAt == null)
                {
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 400,
                        Message = "Un rôle avec ce nom existe déjà",
                        Data = null
                    };
                }

                var role = new RoleApp
                {
                    Id = Guid.NewGuid(),
                    Name = roleDto.Name,
                    NormalizedName = roleDto.Name.ToUpper(),
                    CreatedAt = DateTimeOffset.UtcNow
                };

                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 400,
                        Message = $"Erreur lors de la création du rôle: {errors}",
                        Data = null
                    };
                }

                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 201,
                    Message = "Rôle créé avec succès",
                    Data = new RoleAppResponseDTO(role)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du rôle: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour un rôle existant
        /// </summary>
        /// <param name="id">Identifiant du rôle</param>
        /// <param name="roleDto">Nouvelles données du rôle</param>
        /// <returns>Rôle mis à jour</returns>
        public async Task<ResponseDTO<RoleAppResponseDTO>> UpdateRoleAsync(Guid id, RoleAppUpdateDTO roleDto)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id.ToString());

                if (role == null || role.ArchivedAt != null)
                {
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 404,
                        Message = "Rôle non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour un autre rôle
                var existingRole = await roleManager.FindByNameAsync(roleDto.Name);
                if (existingRole != null && existingRole.Id != id && existingRole.ArchivedAt == null)
                {
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 400,
                        Message = "Un autre rôle avec ce nom existe déjà",
                        Data = null
                    };
                }

                roleDto.UpdateRole(role);
                var result = await roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new ResponseDTO<RoleAppResponseDTO>
                    {
                        Status = 400,
                        Message = $"Erreur lors de la mise à jour du rôle: {errors}",
                        Data = null
                    };
                }

                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 200,
                    Message = "Rôle mis à jour avec succès",
                    Data = new RoleAppResponseDTO(role)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<RoleAppResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du rôle: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère le nombre d'utilisateurs assignés à un rôle
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <returns>Nombre d'utilisateurs</returns>
        public async Task<ResponseDTO<int>> GetUsersCountInRoleAsync(Guid roleId)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId.ToString());
                
                if (role == null || role.ArchivedAt != null)
                {
                    return new ResponseDTO<int>
                    {
                        Status = 404,
                        Message = "Rôle non trouvé",
                        Data = 0
                    };
                }

                var usersInRole = await context.UserRoles
                    .Where(ur => ur.RoleId == roleId)
                    .CountAsync();

                return new ResponseDTO<int>
                {
                    Status = 200,
                    Message = "Nombre d'utilisateurs récupéré avec succès",
                    Data = usersInRole
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<int>
                {
                    Status = 500,
                    Message = $"Erreur lors du comptage des utilisateurs: {ex.Message}",
                    Data = 0
                };
            }
        }
    }
}