using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des niveaux de cursus
    /// </summary>
    public class LevelCursusService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les niveaux de cursus
        /// </summary>
        /// <returns>Liste des niveaux de cursus</returns>
        public async Task<ResponseDTO<List<LevelCursusResponseDTO>>> GetAllLevelCursusAsync()
        {
            try
            {
                var levels = await context.LevelCursuses
                    .AsNoTracking()
                    .Where(l => l.ArchivedAt == null)
                    .OrderBy(l => l.Name)
                    .Select(l => new LevelCursusResponseDTO(l))
                    .ToListAsync();

                return new ResponseDTO<List<LevelCursusResponseDTO>>
                {
                    Status = 200,
                    Message = "Niveaux de cursus récupérés avec succès",
                    Data = levels,
                    Count = levels.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<LevelCursusResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des niveaux de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un niveau de cursus par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du niveau de cursus</param>
        /// <returns>Niveau de cursus trouvé</returns>
        public async Task<ResponseDTO<LevelCursusResponseDTO>> GetLevelCursusByIdAsync(Guid id)
        {
            try
            {
                var level = await context.LevelCursuses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(l => l.Id == id && l.ArchivedAt == null);

                if (level == null)
                {
                    return new ResponseDTO<LevelCursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Niveau de cursus non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 200,
                    Message = "Niveau de cursus récupéré avec succès",
                    Data = new LevelCursusResponseDTO(level)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du niveau de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée un nouveau niveau de cursus
        /// </summary>
        /// <param name="levelDto">Données du niveau de cursus à créer</param>
        /// <returns>Niveau de cursus créé</returns>
        public async Task<ResponseDTO<LevelCursusResponseDTO>> CreateLevelCursusAsync(LevelCursusCreateDTO levelDto)
        {
            try
            {
                // Vérifier que le nom n'existe pas déjà
                var existingLevel = await context.LevelCursuses
                    .AnyAsync(l => l.Name.ToLower() == levelDto.Name.ToLower() && l.ArchivedAt == null);

                if (existingLevel)
                {
                    return new ResponseDTO<LevelCursusResponseDTO>
                    {
                        Status = 400,
                        Message = "Un niveau de cursus avec ce nom existe déjà",
                        Data = null
                    };
                }

                var level = new LevelCursus
                {
                    Id = Guid.NewGuid(),
                    Name = levelDto.Name,
                    Color = levelDto.Color,
                    Icon = levelDto.Icon,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.LevelCursuses.Add(level);
                await context.SaveChangesAsync();

                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 201,
                    Message = "Niveau de cursus créé avec succès",
                    Data = new LevelCursusResponseDTO(level)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du niveau de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour un niveau de cursus existant
        /// </summary>
        /// <param name="id">Identifiant du niveau de cursus</param>
        /// <param name="levelDto">Nouvelles données du niveau de cursus</param>
        /// <returns>Niveau de cursus mis à jour</returns>
        public async Task<ResponseDTO<LevelCursusResponseDTO>> UpdateLevelCursusAsync(Guid id, LevelCursusUpdateDTO levelDto)
        {
            try
            {
                var level = await context.LevelCursuses
                    .FirstOrDefaultAsync(l => l.Id == id && l.ArchivedAt == null);

                if (level == null)
                {
                    return new ResponseDTO<LevelCursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Niveau de cursus non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour un autre niveau
                var existingLevel = await context.LevelCursuses
                    .AnyAsync(l => l.Name.ToLower() == levelDto.Name.ToLower() && l.Id != id && l.ArchivedAt == null);

                if (existingLevel)
                {
                    return new ResponseDTO<LevelCursusResponseDTO>
                    {
                        Status = 400,
                        Message = "Un autre niveau de cursus avec ce nom existe déjà",
                        Data = null
                    };
                }

                level.Name = levelDto.Name;
                level.Color = levelDto.Color;
                level.Icon = levelDto.Icon;
                level.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 200,
                    Message = "Niveau de cursus mis à jour avec succès",
                    Data = new LevelCursusResponseDTO(level)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<LevelCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du niveau de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive un niveau de cursus (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du niveau de cursus</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteLevelCursusAsync(Guid id)
        {
            try
            {
                var level = await context.LevelCursuses
                    .FirstOrDefaultAsync(l => l.Id == id && l.ArchivedAt == null);

                if (level == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Niveau de cursus non trouvé",
                        Data = null
                    };
                }

                // Vérifier si le niveau est utilisé par des cursus
                var isUsedByCursus = await context.Cursuses
                    .AnyAsync(c => c.LevelId == id && c.ArchivedAt == null);

                if (isUsedByCursus)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Ce niveau de cursus est utilisé par des cursus et ne peut pas être supprimé",
                        Data = null
                    };
                }

                level.ArchivedAt = DateTimeOffset.UtcNow;
                level.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Niveau de cursus supprimé avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du niveau de cursus: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}