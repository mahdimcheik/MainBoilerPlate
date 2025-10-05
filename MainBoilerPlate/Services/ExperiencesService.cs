using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des expériences
    /// </summary>
    public class ExperiencesService(MainContext context)
    {
        /// <summary>
        /// Récupère toutes les expériences
        /// </summary>
        /// <returns>Liste des expériences</returns>
        public async Task<ResponseDTO<List<ExperienceResponseDTO>>> GetAllExperiencesAsync()
        {
            try
            {
                var experiences = await context.Experiences
                    .AsNoTracking()
                    .Where(e => e.ArchivedAt == null)
                    .OrderByDescending(e => e.CreatedAt)
                    .Select(e => new ExperienceResponseDTO(e))
                    .ToListAsync();

                return new ResponseDTO<List<ExperienceResponseDTO>>
                {
                    Status = 200,
                    Message = "Expériences récupérées avec succès",
                    Data = experiences,
                    Count = experiences.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<ExperienceResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des expériences: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère une expérience par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'expérience</param>
        /// <returns>Expérience trouvée</returns>
        public async Task<ResponseDTO<ExperienceResponseDTO>> GetExperienceByIdAsync(Guid id)
        {
            try
            {
                var experience = await context.Experiences
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id && e.ArchivedAt == null);

                if (experience == null)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 404,
                        Message = "Expérience non trouvée",
                        Data = null
                    };
                }

                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 200,
                    Message = "Expérience récupérée avec succès",
                    Data = new ExperienceResponseDTO(experience)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération de l'expérience: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère les expériences d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Liste des expériences de l'utilisateur</returns>
        public async Task<ResponseDTO<List<ExperienceResponseDTO>>> GetExperiencesByUserIdAsync(Guid userId)
        {
            try
            {
                var experiences = await context.Experiences
                    .AsNoTracking()
                    .Where(e => e.UserId == userId && e.ArchivedAt == null)
                    .OrderByDescending(e => e.DateFrom)
                    .Select(e => new ExperienceResponseDTO(e))
                    .ToListAsync();

                return new ResponseDTO<List<ExperienceResponseDTO>>
                {
                    Status = 200,
                    Message = "Expériences de l'utilisateur récupérées avec succès",
                    Data = experiences,
                    Count = experiences.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<ExperienceResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des expériences de l'utilisateur: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée une nouvelle expérience
        /// </summary>
        /// <param name="experienceDto">Données de l'expérience à créer</param>
        /// <returns>Expérience créée</returns>
        public async Task<ResponseDTO<ExperienceResponseDTO>> CreateExperienceAsync(ExperienceCreateDTO experienceDto)
        {
            try
            {
                // Vérifier que l'utilisateur existe
                var userExists = await context.Users.AnyAsync(u => u.Id == experienceDto.UserId);
                if (!userExists)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 404,
                        Message = "Utilisateur non trouvé",
                        Data = null
                    };
                }

                // Validation des dates
                if (experienceDto.DateTo.HasValue && experienceDto.DateTo <= experienceDto.DateFrom)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de fin doit être postérieure à la date de début",
                        Data = null
                    };
                }

                var experience = new Experience
                {
                    Id = Guid.NewGuid(),
                    Title = experienceDto.Title,
                    Description = experienceDto.Description,
                    Institution = experienceDto.Institution,
                    DateFrom = experienceDto.DateFrom,
                    DateTo = experienceDto.DateTo,
                    UserId = experienceDto.UserId,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.Experiences.Add(experience);
                await context.SaveChangesAsync();

                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 201,
                    Message = "Expérience créée avec succès",
                    Data = new ExperienceResponseDTO(experience)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création de l'expérience: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour une expérience existante
        /// </summary>
        /// <param name="id">Identifiant de l'expérience</param>
        /// <param name="experienceDto">Nouvelles données de l'expérience</param>
        /// <returns>Expérience mise à jour</returns>
        public async Task<ResponseDTO<ExperienceResponseDTO>> UpdateExperienceAsync(Guid id, ExperienceUpdateDTO experienceDto)
        {
            try
            {
                var experience = await context.Experiences
                    .FirstOrDefaultAsync(e => e.Id == id && e.ArchivedAt == null);

                if (experience == null)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 404,
                        Message = "Expérience non trouvée",
                        Data = null
                    };
                }

                // Vérifier que l'utilisateur existe
                var userExists = await context.Users.AnyAsync(u => u.Id == experienceDto.UserId);
                if (!userExists)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 404,
                        Message = "Utilisateur non trouvé",
                        Data = null
                    };
                }

                // Validation des dates
                if (experienceDto.DateTo.HasValue && experienceDto.DateTo <= experienceDto.DateFrom)
                {
                    return new ResponseDTO<ExperienceResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de fin doit être postérieure à la date de début",
                        Data = null
                    };
                }

                experience.Title = experienceDto.Title;
                experience.Description = experienceDto.Description;
                experience.Institution = experienceDto.Institution;
                experience.DateFrom = experienceDto.DateFrom;
                experience.DateTo = experienceDto.DateTo;
                experience.UserId = experienceDto.UserId;
                experience.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 200,
                    Message = "Expérience mise à jour avec succès",
                    Data = new ExperienceResponseDTO(experience)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ExperienceResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour de l'expérience: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive une expérience (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant de l'expérience</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteExperienceAsync(Guid id)
        {
            try
            {
                var experience = await context.Experiences
                    .FirstOrDefaultAsync(e => e.Id == id && e.ArchivedAt == null);

                if (experience == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Expérience non trouvée",
                        Data = null
                    };
                }

                experience.ArchivedAt = DateTimeOffset.UtcNow;
                experience.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Expérience supprimée avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression de l'expérience: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}