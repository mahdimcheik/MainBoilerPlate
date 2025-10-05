using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour l'affichage des informations d'un cursus
    /// </summary>
    public class CursusResponseDTO
    {
        /// <summary>
        /// Identifiant unique du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom du cursus
        /// </summary>
        /// <example>Formation Développement Web Full Stack</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au cursus (code hexadécimal)
        /// </summary>
        /// <example>#3498db</example>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au cursus
        /// </summary>
        /// <example>fa-code</example>
        public string? Icon { get; set; }

        /// <summary>
        /// Description détaillée du cursus
        /// </summary>
        /// <example>Formation complète en développement web moderne avec React et .NET</example>
        public string? Description { get; set; }

        /// <summary>
        /// URL de l'image du cursus
        /// </summary>
        /// <example>https://example.com/images/cursus-web.jpg</example>
        public string? ImgUrl { get; set; }

        /// <summary>
        /// Identifiant du niveau du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required]
        public Guid LevelId { get; set; }

        /// <summary>
        /// Niveau du cursus
        /// </summary>
        public LevelCursusDTO? Level { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Informations de l'enseignant
        /// </summary>
        public TeacherDTO? Teacher { get; set; }

        /// <summary>
        /// Liste des catégories associées au cursus
        /// </summary>
        public List<CategoryCursusDTO> Categories { get; set; } = new();

        /// <summary>
        /// Date de création de l'enregistrement
        /// </summary>
        /// <example>2023-01-15T10:30:00Z</example>
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Date de dernière mise à jour
        /// </summary>
        /// <example>2023-01-20T14:45:00Z</example>
        public DateTimeOffset? UpdatedAt { get; set; }

        public CursusResponseDTO() { }

        public CursusResponseDTO(Cursus cursus)
        {
            Id = cursus.Id;
            Name = cursus.Name;
            Color = cursus.Color;
            Icon = cursus.Icon;
            Description = cursus.Description;
            ImgUrl = cursus.ImgUrl;
            LevelId = cursus.LevelId;
            Level = cursus.Level != null ? new LevelCursusDTO(cursus.Level) : null;
            TeacherId = cursus.TeacherId;
            Teacher = cursus.Teacher != null ? new TeacherDTO(cursus.Teacher) : null;
            Categories = cursus.Categories?.Select(c => new CategoryCursusDTO(c)).ToList() ?? new List<CategoryCursusDTO>();
            CreatedAt = cursus.CreatedAt;
            UpdatedAt = cursus.UpdatedAt;
        }
    }

    /// <summary>
    /// DTO pour la création d'un nouveau cursus
    /// </summary>
    public class CursusCreateDTO
    {
        /// <summary>
        /// Nom du cursus
        /// </summary>
        /// <example>Formation Développement Web Full Stack</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au cursus (code hexadécimal)
        /// </summary>
        /// <example>#3498db</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #3498db)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au cursus
        /// </summary>
        /// <example>fa-code</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        /// <summary>
        /// Description détaillée du cursus
        /// </summary>
        /// <example>Formation complète en développement web moderne avec React et .NET</example>
        [StringLength(512, ErrorMessage = "La description ne peut pas dépasser 512 caractères")]
        public string? Description { get; set; }

        /// <summary>
        /// URL de l'image du cursus
        /// </summary>
        /// <example>https://example.com/images/cursus-web.jpg</example>
        [StringLength(256, ErrorMessage = "L'URL de l'image ne peut pas dépasser 256 caractères")]
        [Url(ErrorMessage = "L'URL de l'image doit être valide")]
        public string? ImgUrl { get; set; }

        /// <summary>
        /// Identifiant du niveau du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "Le niveau est requis")]
        public Guid LevelId { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'enseignant est requis")]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Liste des identifiants des catégories à associer au cursus
        /// </summary>
        public List<Guid> CategoryIds { get; set; } = new();
    }

    /// <summary>
    /// DTO pour la mise à jour d'un cursus existant
    /// </summary>
    public class CursusUpdateDTO
    {
        /// <summary>
        /// Nom du cursus
        /// </summary>
        /// <example>Formation Développement Web Full Stack</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au cursus (code hexadécimal)
        /// </summary>
        /// <example>#3498db</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #3498db)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au cursus
        /// </summary>
        /// <example>fa-code</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        /// <summary>
        /// Description détaillée du cursus
        /// </summary>
        /// <example>Formation complète en développement web moderne avec React et .NET</example>
        [StringLength(512, ErrorMessage = "La description ne peut pas dépasser 512 caractères")]
        public string? Description { get; set; }

        /// <summary>
        /// URL de l'image du cursus
        /// </summary>
        /// <example>https://example.com/images/cursus-web.jpg</example>
        [StringLength(256, ErrorMessage = "L'URL de l'image ne peut pas dépasser 256 caractères")]
        [Url(ErrorMessage = "L'URL de l'image doit être valide")]
        public string? ImgUrl { get; set; }

        /// <summary>
        /// Identifiant du niveau du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "Le niveau est requis")]
        public Guid LevelId { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'enseignant est requis")]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Liste des identifiants des catégories à associer au cursus
        /// </summary>
        public List<Guid> CategoryIds { get; set; } = new();
    }

    /// <summary>
    /// DTO pour le niveau de cursus
    /// </summary>
    public class LevelCursusDTO
    {
        /// <summary>
        /// Identifiant du niveau
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom du niveau
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur du niveau
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône du niveau
        /// </summary>
        public string? Icon { get; set; }

        public LevelCursusDTO() { }

        public LevelCursusDTO(LevelCursus level)
        {
            Id = level.Id;
            Name = level.Name;
            Color = level.Color;
            Icon = level.Icon;
        }
    }

    /// <summary>
    /// DTO pour la catégorie de cursus
    /// </summary>
    public class CategoryCursusDTO
    {
        /// <summary>
        /// Identifiant de la catégorie
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom de la catégorie
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur de la catégorie
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône de la catégorie
        /// </summary>
        public string? Icon { get; set; }

        public CategoryCursusDTO() { }

        public CategoryCursusDTO(CategoryCursus category)
        {
            Id = category.Id;
            Name = category.Name;
            Color = category.Color;
            Icon = category.Icon;
        }
    }

    /// <summary>
    /// DTO pour l'enseignant simplifié
    /// </summary>
    public class TeacherDTO
    {
        /// <summary>
        /// Identifiant de l'enseignant
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Prénom de l'enseignant
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Nom de famille de l'enseignant
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email de l'enseignant
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Titre de l'enseignant
        /// </summary>
        public string? Title { get; set; }

        public TeacherDTO() { }

        public TeacherDTO(UserApp teacher)
        {
            Id = teacher.Id;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            Email = teacher.Email ?? "";
            Title = teacher.Title;
        }
    }

    /// <summary>
    /// DTO pour associer/dissocier une catégorie à un cursus
    /// </summary>
    public class CursusCategoryDTO
    {
        /// <summary>
        /// Identifiant du cursus
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant du cursus est requis")]
        public Guid CursusId { get; set; }

        /// <summary>
        /// Identifiant de la catégorie
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'identifiant de la catégorie est requis")]
        public Guid CategoryId { get; set; }
    }
}