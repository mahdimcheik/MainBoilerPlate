using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des catégories de cursus
    /// </summary>
    public class CategoryCursusService(MainContext context)
    {
        /// <summary>
        /// Récupère toutes les catégories de cursus
        /// </summary>
        /// <returns>Liste des catégories de cursus</returns>
        public async Task<ResponseDTO<List<CategoryCursusResponseDTO>>> GetAllCategoryCursusAsync()
        {
            try
            {
                var categories = await context.CategoryCursuses
                    .AsNoTracking()
                    .Where(c => c.ArchivedAt == null)
                    .OrderBy(c => c.Name)
                    .Select(c => new CategoryCursusResponseDTO(c))
                    .ToListAsync();

                return new ResponseDTO<List<CategoryCursusResponseDTO>>
                {
                    Status = 200,
                    Message = "Catégories de cursus récupérées avec succès",
                    Data = categories,
                    Count = categories.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<CategoryCursusResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des catégories de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère une catégorie de cursus par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de cursus</param>
        /// <returns>Catégorie de cursus trouvée</returns>
        public async Task<ResponseDTO<CategoryCursusResponseDTO>> GetCategoryCursusByIdAsync(Guid id)
        {
            try
            {
                var category = await context.CategoryCursuses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (category == null)
                {
                    return new ResponseDTO<CategoryCursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Catégorie de cursus non trouvée",
                        Data = null
                    };
                }

                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 200,
                    Message = "Catégorie de cursus récupérée avec succès",
                    Data = new CategoryCursusResponseDTO(category)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération de la catégorie de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crée une nouvelle catégorie de cursus
        /// </summary>
        /// <param name="categoryDto">Données de la catégorie de cursus à créer</param>
        /// <returns>Catégorie de cursus créée</returns>
        public async Task<ResponseDTO<CategoryCursusResponseDTO>> CreateCategoryCursusAsync(CategoryCursusCreateDTO categoryDto)
        {
            try
            {
                // Vérifier que le nom n'existe pas déjà
                var existingCategory = await context.CategoryCursuses
                    .AnyAsync(c => c.Name.ToLower() == categoryDto.Name.ToLower() && c.ArchivedAt == null);

                if (existingCategory)
                {
                    return new ResponseDTO<CategoryCursusResponseDTO>
                    {
                        Status = 400,
                        Message = "Une catégorie de cursus avec ce nom existe déjà",
                        Data = null
                    };
                }

                var category = new CategoryCursus
                {
                    Id = Guid.NewGuid(),
                    Name = categoryDto.Name,
                    Color = categoryDto.Color,
                    Icon = categoryDto.Icon,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.CategoryCursuses.Add(category);
                await context.SaveChangesAsync();

                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 201,
                    Message = "Catégorie de cursus créée avec succès",
                    Data = new CategoryCursusResponseDTO(category)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création de la catégorie de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour une catégorie de cursus existante
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de cursus</param>
        /// <param name="categoryDto">Nouvelles données de la catégorie de cursus</param>
        /// <returns>Catégorie de cursus mise à jour</returns>
        public async Task<ResponseDTO<CategoryCursusResponseDTO>> UpdateCategoryCursusAsync(Guid id, CategoryCursusUpdateDTO categoryDto)
        {
            try
            {
                var category = await context.CategoryCursuses
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (category == null)
                {
                    return new ResponseDTO<CategoryCursusResponseDTO>
                    {
                        Status = 404,
                        Message = "Catégorie de cursus non trouvée",
                        Data = null
                    };
                }

                // Vérifier que le nom n'existe pas déjà pour une autre catégorie
                var existingCategory = await context.CategoryCursuses
                    .AnyAsync(c => c.Name.ToLower() == categoryDto.Name.ToLower() && c.Id != id && c.ArchivedAt == null);

                if (existingCategory)
                {
                    return new ResponseDTO<CategoryCursusResponseDTO>
                    {
                        Status = 400,
                        Message = "Une autre catégorie de cursus avec ce nom existe déjà",
                        Data = null
                    };
                }

                category.Name = categoryDto.Name;
                category.Color = categoryDto.Color;
                category.Icon = categoryDto.Icon;
                category.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 200,
                    Message = "Catégorie de cursus mise à jour avec succès",
                    Data = new CategoryCursusResponseDTO(category)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CategoryCursusResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour de la catégorie de cursus: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Archive une catégorie de cursus (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de cursus</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteCategoryCursusAsync(Guid id)
        {
            try
            {
                var category = await context.CategoryCursuses
                    .FirstOrDefaultAsync(c => c.Id == id && c.ArchivedAt == null);

                if (category == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Catégorie de cursus non trouvée",
                        Data = null
                    };
                }

                // Vérifier si la catégorie est utilisée par des cursus
                var isUsedByCursus = await context.Cursuses
                    .AnyAsync(c => c.Categories.Any(cat => cat.Id == id) && c.ArchivedAt == null);

                if (isUsedByCursus)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Cette catégorie de cursus est utilisée par des cursus et ne peut pas être supprimée",
                        Data = null
                    };
                }

                category.ArchivedAt = DateTimeOffset.UtcNow;
                category.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Catégorie de cursus supprimée avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression de la catégorie de cursus: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}