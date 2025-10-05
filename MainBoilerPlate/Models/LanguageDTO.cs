using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour l'affichage des informations d'une langue
    /// </summary>
    public class LanguageResponseDTO
    {
        /// <summary>
        /// Identifiant unique de la langue
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom de la langue
        /// </summary>
        /// <example>Français</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée à la langue (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée à la langue
        /// </summary>
        /// <example>fa-flag-france</example>
        public string? Icon { get; set; }

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

        public LanguageResponseDTO() { }

        public LanguageResponseDTO(Language language)
        {
            Id = language.Id;
            Name = language.Name;
            Color = language.Color;
            Icon = language.Icon;
            CreatedAt = language.CreatedAt;
            UpdatedAt = language.UpdatedAt;
        }
    }

    /// <summary>
    /// DTO pour la création d'une nouvelle langue
    /// </summary>
    public class LanguageCreateDTO
    {
        /// <summary>
        /// Nom de la langue
        /// </summary>
        /// <example>Français</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée à la langue (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée à la langue
        /// </summary>
        /// <example>fa-flag-france</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'une langue existante
    /// </summary>
    public class LanguageUpdateDTO
    {
        /// <summary>
        /// Nom de la langue
        /// </summary>
        /// <example>Français</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée à la langue (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée à la langue
        /// </summary>
        /// <example>fa-flag-france</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO pour associer/dissocier une langue à un utilisateur
    /// </summary>
    public class UserLanguageDTO
    {
        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant utilisateur est requis")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Identifiant de la langue
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'identifiant de la langue est requis")]
        public Guid LanguageId { get; set; }
    }
}