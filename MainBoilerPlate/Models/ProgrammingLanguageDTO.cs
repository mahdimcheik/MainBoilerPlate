using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour l'affichage des informations d'un langage de programmation
    /// </summary>
    public class ProgrammingLanguageResponseDTO
    {
        /// <summary>
        /// Identifiant unique du langage de programmation
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom du langage de programmation
        /// </summary>
        /// <example>C#</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au langage (code hexadécimal)
        /// </summary>
        /// <example>#239120</example>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au langage
        /// </summary>
        /// <example>fa-brands fa-microsoft</example>
        public string? Icon { get; set; }

        /// <summary>
        /// Description du langage de programmation
        /// </summary>
        /// <example>Langage de programmation orienté objet développé par Microsoft</example>
        public string? Description { get; set; }

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

        public ProgrammingLanguageResponseDTO() { }

        public ProgrammingLanguageResponseDTO(ProgrammingLanguage programmingLanguage)
        {
            Id = programmingLanguage.Id;
            Name = programmingLanguage.Name;
            Color = programmingLanguage.Color;
            Icon = programmingLanguage.Icon;
            Description = programmingLanguage.Description;
            CreatedAt = programmingLanguage.CreatedAt;
            UpdatedAt = programmingLanguage.UpdatedAt;
        }
    }

    /// <summary>
    /// DTO pour la création d'un nouveau langage de programmation
    /// </summary>
    public class ProgrammingLanguageCreateDTO
    {
        /// <summary>
        /// Nom du langage de programmation
        /// </summary>
        /// <example>C#</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au langage (code hexadécimal)
        /// </summary>
        /// <example>#239120</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #239120)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au langage
        /// </summary>
        /// <example>fa-brands fa-microsoft</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        /// <summary>
        /// Description du langage de programmation
        /// </summary>
        /// <example>Langage de programmation orienté objet développé par Microsoft</example>
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string? Description { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'un langage de programmation existant
    /// </summary>
    public class ProgrammingLanguageUpdateDTO
    {
        /// <summary>
        /// Nom du langage de programmation
        /// </summary>
        /// <example>C#</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au langage (code hexadécimal)
        /// </summary>
        /// <example>#239120</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #239120)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au langage
        /// </summary>
        /// <example>fa-brands fa-microsoft</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        /// <summary>
        /// Description du langage de programmation
        /// </summary>
        /// <example>Langage de programmation orienté objet développé par Microsoft</example>
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string? Description { get; set; }
    }

    /// <summary>
    /// DTO pour associer/dissocier un langage de programmation à un utilisateur
    /// </summary>
    public class UserProgrammingLanguageDTO
    {
        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant utilisateur est requis")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Identifiant du langage de programmation
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'identifiant du langage de programmation est requis")]
        public Guid ProgrammingLanguageId { get; set; }
    }
}