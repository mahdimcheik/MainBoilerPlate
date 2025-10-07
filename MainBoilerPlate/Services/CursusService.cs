using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des cursus
    /// </summary>
    public class CursusService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les cursus
        /// </summary>
        /// <returns>Liste des cursus</returns>
        public async Task<ResponseDTO<List<CursusResponseDTO>>> GetAllCursusAsync()
        {
            try
            {
                var cursuses = await context.Cursuses
                    .AsNoTracking()
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .Where(c => c.ArchivedAt == null)
                    .OrderByDescending(c => c.CreatedAt)
                    .Select(c => new CursusResponseDTO(c))
                    .ToListAsync();

                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 200,
                    Message = "Cursus récupérés avec succès",
                    Data = cursuses,
                    Count = cursuses.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un cursus par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du cursus</param>
        /// <returns>Cursus trouvé</returns>
        public async Task<ResponseDTO<CursusResponseDTO>> GetCursusByIdAsync(Guid id)
        {
            try
            {
                var cursus = await context.Cursuses
                    .AsNoTracking()
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (cursus == null)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Cursus non trouvé",
                        Data = null
                    };
                }

                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 200,
                    Message = "Cursus récupéré avec succès",
                    Data = new CursusResponseDTO(cursus)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère les cursus d'un enseignant
        /// </summary>
        /// <param name="teacherId">Identifiant de l'enseignant</param>
        /// <returns>Liste des cursus de l'enseignant</returns>
        public async Task<ResponseDTO<List<CursusResponseDTO>>> GetCursusByTeacherIdAsync(Guid teacherId)
        {
            try
            {
                var cursuses = await context.Cursuses
                    .AsNoTracking()
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .Where(c => c.TeacherId == teacherId && c.ArchivedAt == null)
                    .OrderByDescending(c => c.CreatedAt)
                    .Select(c => new CursusResponseDTO(c))
                    .ToListAsync();

                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 200,
                    Message = "Cursus de l'enseignant récupérés avec succès",
                    Data = cursuses,
                    Count = cursuses.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des cursus de l'enseignant: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère les cursus par niveau
        /// </summary>
        /// <param name="levelId">Identifiant du niveau</param>
        /// <returns>Liste des cursus du niveau</returns>
        public async Task<ResponseDTO<List<CursusResponseDTO>>> GetCursusByLevelIdAsync(Guid levelId)
        {
            try
            {
                var cursuses = await context.Cursuses
                    .AsNoTracking()
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .Where(c => c.LevelId == levelId && c.ArchivedAt == null)
                    .OrderByDescending(c => c.CreatedAt)
                    .Select(c => new CursusResponseDTO(c))
                    .ToListAsync();

                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 200,
                    Message = "Cursus du niveau récupérés avec succès",
                    Data = cursuses,
                    Count = cursuses.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<CursusResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des cursus du niveau: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée un nouveau cursus
        /// </summary>
        /// <param name="cursusDto">Données du cursus à créer</param>
        /// <returns>Cursus créé</returns>
        public async Task<ResponseDTO<CursusResponseDTO>> CreateCursusAsync(CursusCreateDTO cursusDto)
        {
            try
            {
                // Vérifier que le niveau existe
                var levelExists = await context.LevelCursuses.AnyAsync(l => l.Id == cursusDto.LevelId && l.ArchivedAt == null);
                if (!levelExists)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Niveau non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'enseignant existe
                var teacherExists = await context.Users.AnyAsync(u => u.Id == cursusDto.TeacherId);
                if (!teacherExists)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Enseignant non trouvé",
                        Data = null
                    };
                }

                //// Vérifier que le nom n'existe pas déjà
                //var existingCursus = await context.Cursuses
                //    .AnyAsync(c => c.Name.ToLower() == cursusDto.Name.ToLower() && c.ArchivedAt == null);

                //if (existingCursus)
                //{
                //    return new ResponseDTO<CursusResponseDTO>
                //    {
                //        Status = 400,
                //        Message = "Un cursus avec ce nom existe déjà",
                //        Data = null
                //    };
                //}

                // Vérifier que les catégories existent
                var categories = new List<CategoryCursus>();
                if (cursusDto.CategoryIds.Any())
                {
                    categories = await context.CategoryCursuses
                        .Where(c => cursusDto.CategoryIds.Contains(c.Id) && c.ArchivedAt == null)
                        .ToListAsync();

                    if (categories.Count != cursusDto.CategoryIds.Count)
                    {
                        return new ResponseDTO<CursusResponseDTO>
                        {
                            Status = 404,
                            Message = "Une ou plusieurs catégories non trouvées",
                            Data = null
                        };
                    }
                }

                var cursus = new Cursus
                {
                    Id = Guid.NewGuid(),
                    Name = cursusDto.Name,
                    Color = cursusDto.Color,
                    Icon = cursusDto.Icon,
                    Description = cursusDto.Description,
                    ImgUrl = cursusDto.ImgUrl,
                    LevelId = cursusDto.LevelId,
                    TeacherId = cursusDto.TeacherId,
                    Categories = categories,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.Cursuses.Add(cursus);
                await context.SaveChangesAsync();

                // Recharger avec les relations pour la réponse
                var createdCursus = await context.Cursuses
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .FirstAsync(c => c.Id == cursus.Id);

                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 201,
                    Message = "Cursus créé avec succès",
                    Data = new CursusResponseDTO(createdCursus)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour un cursus existant
        /// </summary>
        /// <param name="id">Identifiant du cursus</param>
        /// <param name="cursusDto">Nouvelles données du cursus</param>
        /// <returns>Cursus mis à jour</returns>
        public async Task<ResponseDTO<CursusResponseDTO>> UpdateCursusAsync(Guid id, CursusUpdateDTO cursusDto)
        {
            try
            {
                var cursus = await context.Cursuses
                    .Include(c => c.Categories)
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (cursus == null)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Cursus non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le niveau existe
                var levelExists = await context.LevelCursuses.AnyAsync(l => l.Id == cursusDto.LevelId && l.ArchivedAt == null);
                if (!levelExists)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Niveau non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'enseignant existe
                var teacherExists = await context.Users.AnyAsync(u => u.Id == cursusDto.TeacherId);
                if (!teacherExists)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Enseignant non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour un autre cursus
                var existingCursus = await context.Cursuses
                    .AnyAsync(c => c.Name.ToLower() == cursusDto.Name.ToLower() && c.Id != id && c.ArchivedAt == null);

                if (existingCursus)
                {
                    return new ResponseDTO<CursusResponseDTO>
                    {
                        Status = 400,
                        Message = "Un autre cursus avec ce nom existe déjà",
                        Data = null
                    };
                }

                // Vérifier que les catégories existent
                var categories = new List<CategoryCursus>();
                if (cursusDto.CategoryIds.Any())
                {
                    categories = await context.CategoryCursuses
                        .Where(c => cursusDto.CategoryIds.Contains(c.Id) && c.ArchivedAt == null)
                        .ToListAsync();

                    if (categories.Count != cursusDto.CategoryIds.Count)
                    {
                        return new ResponseDTO<CursusResponseDTO>
                        {
                            Status = 404,
                            Message = "Une ou plusieurs catégories non trouvées",
                            Data = null
                        };
                    }
                }

                cursus.Name = cursusDto.Name;
                cursus.Color = cursusDto.Color;
                cursus.Icon = cursusDto.Icon;
                cursus.Description = cursusDto.Description;
                cursus.ImgUrl = cursusDto.ImgUrl;
                cursus.LevelId = cursusDto.LevelId;
                cursus.TeacherId = cursusDto.TeacherId;
                cursus.Categories = categories;
                cursus.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                // Recharger avec les relations pour la réponse
                var updatedCursus = await context.Cursuses
                    .Include(c => c.Level)
                    .Include(c => c.Teacher)
                    .Include(c => c.Categories)
                    .FirstAsync(c => c.Id == id);

                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 200,
                    Message = "Cursus mis à jour avec succès",
                    Data = new CursusResponseDTO(updatedCursus)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive un cursus (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du cursus</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteCursusAsync(Guid id)
        {
            try
            {
                var cursus = await context.Cursuses
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (cursus == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Cursus non trouvé",
                        Data = null
                    };
                }

                cursus.ArchivedAt = DateTimeOffset.UtcNow;
                cursus.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Cursus supprimé avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Associe une catégorie à un cursus
        /// </summary>
        /// <param name="cursusCategoryDto">Données d'association cursus-catégorie</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> AddCategoryToCursusAsync(CursusCategoryDTO cursusCategoryDto)
        {
            try
            {
                // Vérifier que le cursus existe
                var cursus = await context.Cursuses
                    .Include(c => c.Categories)
                    .FirstOrDefaultAsync(c => c.Id == cursusCategoryDto.CursusId && c.ArchivedAt == null);

                if (cursus == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Cursus non trouvé",
                        Data = null
                    };
                }

                // Vérifier que la catégorie existe
                var category = await context.CategoryCursuses
                    .FirstOrDefaultAsync(c => c.Id == cursusCategoryDto.CategoryId && c.ArchivedAt == null);

                if (category == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Catégorie non trouvée",
                        Data = null
                    };
                }

                // Vérifier que l'association n'existe pas déjà
                if (cursus.Categories.Any(c => c.Id == cursusCategoryDto.CategoryId))
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Cette catégorie est déjà associée au cursus",
                        Data = null
                    };
                }

                cursus.Categories.Add(category);
                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Catégorie associée au cursus avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de l'association de la catégorie au cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Dissocie une catégorie d'un cursus
        /// </summary>
        /// <param name="cursusCategoryDto">Données de dissociation cursus-catégorie</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> RemoveCategoryFromCursusAsync(CursusCategoryDTO cursusCategoryDto)
        {
            try
            {
                // Vérifier que le cursus existe
                var cursus = await context.Cursuses
                    .Include(c => c.Categories)
                    .FirstOrDefaultAsync(c => c.Id == cursusCategoryDto.CursusId && c.ArchivedAt == null);

                if (cursus == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Cursus non trouvé",
                        Data = null
                    };
                }

                // Trouver la catégorie dans les catégories du cursus
                var category = cursus.Categories.FirstOrDefault(c => c.Id == cursusCategoryDto.CategoryId);

                if (category == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Cette catégorie n'est pas associée au cursus",
                        Data = null
                    };
                }

                cursus.Categories.Remove(category);
                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Catégorie dissociée du cursus avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la dissociation de la catégorie du cursus: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}