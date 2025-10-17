using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des statuts de compte
    /// </summary>
    public class StatusAccountService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les statuts de compte
        /// </summary>
        /// <returns>Liste des statuts de compte</returns>
        public async Task<ResponseDTO<List<StatusAccountResponseDTO>>> GetAllStatusAccountsAsync(DynamicFilters<StatusAccount> tableState)
        {
            try
            {
                var query = context.Statuses
                    .AsNoTracking()
                    .Where(s => s.ArchivedAt == null)
                    .OrderBy(s => s.Name);
                //.Select(s => new StatusAccountResponseDTO(s))
                //.ToListAsync();

                var statuses = await query.ApplyAndCountAsync(tableState);

                return new ResponseDTO<List<StatusAccountResponseDTO>>
                {
                    Status = 200,
                    Message = "Statuts de compte récupérés avec succès",
                    Data = statuses.Values.Select(x => new StatusAccountResponseDTO(x)).ToList(),
                    Count = statuses.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<StatusAccountResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des statuts de compte: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un statut de compte par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du statut de compte</param>
        /// <returns>Statut de compte trouvé</returns>
        public async Task<ResponseDTO<StatusAccountResponseDTO>> GetStatusAccountByIdAsync(Guid id)
        {
            try
            {
                var status = await context.Statuses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == id && s.ArchivedAt == null);

                if (status == null)
                {
                    return new ResponseDTO<StatusAccountResponseDTO>
                    {
                        Status = 404,
                        Message = "Statut de compte non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 200,
                    Message = "Statut de compte récupéré avec succès",
                    Data = new StatusAccountResponseDTO(status)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du statut de compte: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée un nouveau statut de compte
        /// </summary>
        /// <param name="statusDto">Données du statut de compte à créer</param>
        /// <returns>Statut de compte créé</returns>
        public async Task<ResponseDTO<StatusAccountResponseDTO>> CreateStatusAccountAsync(StatusAccountCreateDTO statusDto)
        {
            try
            {
                // Vérifier que le nom n'existe pas déjà
                var existingStatus = await context.Statuses
                    .AnyAsync(s => s.Name.ToLower() == statusDto.Name.ToLower() && s.ArchivedAt == null);

                if (existingStatus)
                {
                    return new ResponseDTO<StatusAccountResponseDTO>
                    {
                        Status = 400,
                        Message = "Un statut de compte avec ce nom existe déjà",
                        Data = null
                    };
                }

                var status = new StatusAccount
                {
                    Id = Guid.NewGuid(),
                    Name = statusDto.Name,
                    Color = statusDto.Color,
                    Icon = statusDto.Icon,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.Statuses.Add(status);
                await context.SaveChangesAsync();

                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 201,
                    Message = "Statut de compte créé avec succès",
                    Data = new StatusAccountResponseDTO(status)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du statut de compte: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour un statut de compte existant
        /// </summary>
        /// <param name="id">Identifiant du statut de compte</param>
        /// <param name="statusDto">Nouvelles données du statut de compte</param>
        /// <returns>Statut de compte mis à jour</returns>
        public async Task<ResponseDTO<StatusAccountResponseDTO>> UpdateStatusAccountAsync(Guid id, StatusAccountUpdateDTO statusDto)
        {
            try
            {
                var status = await context.Statuses
                    .FirstOrDefaultAsync(s => s.Id == id && s.ArchivedAt == null);

                if (status == null)
                {
                    return new ResponseDTO<StatusAccountResponseDTO>
                    {
                        Status = 404,
                        Message = "Statut de compte non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour un autre statut
                var existingStatus = await context.Statuses
                    .AnyAsync(s => s.Name.ToLower() == statusDto.Name.ToLower() && s.Id != id && s.ArchivedAt == null);

                if (existingStatus)
                {
                    return new ResponseDTO<StatusAccountResponseDTO>
                    {
                        Status = 400,
                        Message = "Un autre statut de compte avec ce nom existe déjà",
                        Data = null
                    };
                }

                statusDto.UpdateStatusAccount(status);
                await context.SaveChangesAsync();

                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 200,
                    Message = "Statut de compte mis à jour avec succès",
                    Data = new StatusAccountResponseDTO(status)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<StatusAccountResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du statut de compte: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive un statut de compte (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du statut de compte</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteStatusAccountAsync(Guid id)
        {
            try
            {
                var status = await context.Statuses
                    .FirstOrDefaultAsync(s => s.Id == id && s.ArchivedAt == null);

                if (status == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Statut de compte non trouvé",
                        Data = null
                    };
                }

                // Vérifier si le statut est utilisé par des utilisateurs
                var isUsedByUsers = await context.Users
                    .AnyAsync(u => u.StatusId == id && u.ArchivedAt == null);

                if (isUsedByUsers)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Ce statut de compte est utilisé par des utilisateurs et ne peut pas être supprimé",
                        Data = null
                    };
                }

                status.ArchivedAt = DateTimeOffset.UtcNow;
                status.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Statut de compte supprimé avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du statut de compte: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}