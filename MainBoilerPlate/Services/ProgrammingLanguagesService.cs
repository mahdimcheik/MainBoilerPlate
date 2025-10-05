using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des langages de programmation
    /// </summary>
    public class ProgrammingLanguagesService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les langages de programmation
        /// </summary>
        /// <returns>Liste des langages de programmation</returns>
        public async Task<ResponseDTO<List<ProgrammingLanguageResponseDTO>>> GetAllProgrammingLanguagesAsync()
        {
            try
            {
                var programmingLanguages = await context.ProgrammingLanguages
                    .AsNoTracking()
                    .Where(pl => pl.ArchivedAt == null)
                    .OrderBy(pl => pl.Name)
                    .Select(pl => new ProgrammingLanguageResponseDTO(pl))
                    .ToListAsync();

                return new ResponseDTO<List<ProgrammingLanguageResponseDTO>>
                {
                    Status = 200,
                    Message = "Langages de programmation récupérés avec succès",
                    Data = programmingLanguages,
                    Count = programmingLanguages.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<ProgrammingLanguageResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des langages de programmation: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un langage de programmation par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du langage de programmation</param>
        /// <returns>Langage de programmation trouvé</returns>
        public async Task<ResponseDTO<ProgrammingLanguageResponseDTO>> GetProgrammingLanguageByIdAsync(Guid id)
        {
            try
            {
                var programmingLanguage = await context.ProgrammingLanguages
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pl => pl.Id == id && pl.ArchivedAt == null);

                if (programmingLanguage == null)
                {
                    return new ResponseDTO<ProgrammingLanguageResponseDTO>
                    {
                        Status = 404,
                        Message = "Langage de programmation non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 200,
                    Message = "Langage de programmation récupéré avec succès",
                    Data = new ProgrammingLanguageResponseDTO(programmingLanguage)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du langage de programmation: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère les langages de programmation d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Liste des langages de programmation de l'utilisateur</returns>
        public async Task<ResponseDTO<List<ProgrammingLanguageResponseDTO>>> GetProgrammingLanguagesByUserIdAsync(Guid userId)
        {
            try
            {
                var programmingLanguages = await context.Users
                    .AsNoTracking()
                    .Where(u => u.Id == userId)
                    .SelectMany(u => u.ProgrammingLanguages)
                    .Where(pl => pl.ArchivedAt == null)
                    .OrderBy(pl => pl.Name)
                    .Select(pl => new ProgrammingLanguageResponseDTO(pl))
                    .ToListAsync();

                return new ResponseDTO<List<ProgrammingLanguageResponseDTO>>
                {
                    Status = 200,
                    Message = "Langages de programmation de l'utilisateur récupérés avec succès",
                    Data = programmingLanguages,
                    Count = programmingLanguages.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<ProgrammingLanguageResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des langages de programmation de l'utilisateur: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée un nouveau langage de programmation
        /// </summary>
        /// <param name="programmingLanguageDto">Données du langage de programmation à créer</param>
        /// <returns>Langage de programmation créé</returns>
        public async Task<ResponseDTO<ProgrammingLanguageResponseDTO>> CreateProgrammingLanguageAsync(ProgrammingLanguageCreateDTO programmingLanguageDto)
        {
            try
            {
                // Vérifier que le nom n'existe pas déjà
                var existingProgrammingLanguage = await context.ProgrammingLanguages
                    .AnyAsync(pl => pl.Name.ToLower() == programmingLanguageDto.Name.ToLower() && pl.ArchivedAt == null);

                if (existingProgrammingLanguage)
                {
                    return new ResponseDTO<ProgrammingLanguageResponseDTO>
                    {
                        Status = 400,
                        Message = "Un langage de programmation avec ce nom existe déjà",
                        Data = null
                    };
                }

                var programmingLanguage = new ProgrammingLanguage
                {
                    Id = Guid.NewGuid(),
                    Name = programmingLanguageDto.Name,
                    Color = programmingLanguageDto.Color,
                    Icon = programmingLanguageDto.Icon,
                    Description = programmingLanguageDto.Description,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.ProgrammingLanguages.Add(programmingLanguage);
                await context.SaveChangesAsync();

                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 201,
                    Message = "Langage de programmation créé avec succès",
                    Data = new ProgrammingLanguageResponseDTO(programmingLanguage)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du langage de programmation: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour un langage de programmation existant
        /// </summary>
        /// <param name="id">Identifiant du langage de programmation</param>
        /// <param name="programmingLanguageDto">Nouvelles données du langage de programmation</param>
        /// <returns>Langage de programmation mis à jour</returns>
        public async Task<ResponseDTO<ProgrammingLanguageResponseDTO>> UpdateProgrammingLanguageAsync(Guid id, ProgrammingLanguageUpdateDTO programmingLanguageDto)
        {
            try
            {
                var programmingLanguage = await context.ProgrammingLanguages
                    .FirstOrDefaultAsync(pl => pl.Id == id && pl.ArchivedAt == null);

                if (programmingLanguage == null)
                {
                    return new ResponseDTO<ProgrammingLanguageResponseDTO>
                    {
                        Status = 404,
                        Message = "Langage de programmation non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour un autre langage de programmation
                var existingProgrammingLanguage = await context.ProgrammingLanguages
                    .AnyAsync(pl => pl.Name.ToLower() == programmingLanguageDto.Name.ToLower() && pl.Id != id && pl.ArchivedAt == null);

                if (existingProgrammingLanguage)
                {
                    return new ResponseDTO<ProgrammingLanguageResponseDTO>
                    {
                        Status = 400,
                        Message = "Un autre langage de programmation avec ce nom existe déjà",
                        Data = null
                    };
                }

                programmingLanguage.Name = programmingLanguageDto.Name;
                programmingLanguage.Color = programmingLanguageDto.Color;
                programmingLanguage.Icon = programmingLanguageDto.Icon;
                programmingLanguage.Description = programmingLanguageDto.Description;
                programmingLanguage.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 200,
                    Message = "Langage de programmation mis à jour avec succès",
                    Data = new ProgrammingLanguageResponseDTO(programmingLanguage)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProgrammingLanguageResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du langage de programmation: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive un langage de programmation (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du langage de programmation</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteProgrammingLanguageAsync(Guid id)
        {
            try
            {
                var programmingLanguage = await context.ProgrammingLanguages
                    .FirstOrDefaultAsync(pl => pl.Id == id && pl.ArchivedAt == null);

                if (programmingLanguage == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Langage de programmation non trouvé",
                        Data = null
                    };
                }

                programmingLanguage.ArchivedAt = DateTimeOffset.UtcNow;
                programmingLanguage.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Langage de programmation supprimé avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du langage de programmation: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Associe un langage de programmation à un utilisateur
        /// </summary>
        /// <param name="userProgrammingLanguageDto">Données d'association utilisateur-langage de programmation</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> AddProgrammingLanguageToUserAsync(UserProgrammingLanguageDTO userProgrammingLanguageDto)
        {
            try
            {
                // Vérifier que l'utilisateur existe
                var user = await context.Users
                    .Include(u => u.ProgrammingLanguages)
                    .FirstOrDefaultAsync(u => u.Id == userProgrammingLanguageDto.UserId);

                if (user == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Utilisateur non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le langage de programmation existe
                var programmingLanguage = await context.ProgrammingLanguages
                    .FirstOrDefaultAsync(pl => pl.Id == userProgrammingLanguageDto.ProgrammingLanguageId && pl.ArchivedAt == null);

                if (programmingLanguage == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Langage de programmation non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'association n'existe pas déjà
                if (user.ProgrammingLanguages.Any(pl => pl.Id == userProgrammingLanguageDto.ProgrammingLanguageId))
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Ce langage de programmation est déjà associé à l'utilisateur",
                        Data = null
                    };
                }

                user.ProgrammingLanguages.Add(programmingLanguage);
                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Langage de programmation associé à l'utilisateur avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de l'association du langage de programmation à l'utilisateur: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Dissocie un langage de programmation d'un utilisateur
        /// </summary>
        /// <param name="userProgrammingLanguageDto">Données de dissociation utilisateur-langage de programmation</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> RemoveProgrammingLanguageFromUserAsync(UserProgrammingLanguageDTO userProgrammingLanguageDto)
        {
            try
            {
                // Vérifier que l'utilisateur existe
                var user = await context.Users
                    .Include(u => u.ProgrammingLanguages)
                    .FirstOrDefaultAsync(u => u.Id == userProgrammingLanguageDto.UserId);

                if (user == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Utilisateur non trouvé",
                        Data = null
                    };
                }

                // Trouver le langage de programmation dans les langages de l'utilisateur
                var programmingLanguage = user.ProgrammingLanguages.FirstOrDefault(pl => pl.Id == userProgrammingLanguageDto.ProgrammingLanguageId);

                if (programmingLanguage == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Ce langage de programmation n'est pas associé à l'utilisateur",
                        Data = null
                    };
                }

                user.ProgrammingLanguages.Remove(programmingLanguage);
                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Langage de programmation dissocié de l'utilisateur avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la dissociation du langage de programmation de l'utilisateur: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}