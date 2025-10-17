using System.ComponentModel.DataAnnotations;
using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class StatusAccount : BaseModelOption { }

    /// <summary>
    /// DTO pour l'affichage des informations d'un statut de compte
    /// </summary>
    public class StatusAccountDTO(StatusAccount status)
    {
        /// <summary>
        /// Identifiant unique du statut
        /// </summary>
        [Required]
        public Guid Id => status.Id;
        
        /// <summary>
        /// Nom du statut
        /// </summary>
        [Required]
        public string Name => status.Name;
        
        /// <summary>
        /// Couleur associée au statut (code hexadécimal)
        /// </summary>
        [Required]
        public string Color => status.Color;
        
        /// <summary>
        /// Icône associée au statut
        /// </summary>
        public string? Icon => status.Icon;
    }

    /// <summary>
    /// DTO pour l'affichage détaillé d'un statut de compte
    /// </summary>
    public class StatusAccountResponseDTO
    {
        /// <summary>
        /// Identifiant unique du statut
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom du statut
        /// </summary>
        /// <example>Confirmed</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au statut (code hexadécimal)
        /// </summary>
        /// <example>#28a745</example>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au statut
        /// </summary>
        /// <example>fa-check-circle</example>
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

        public StatusAccountResponseDTO() { }

        public StatusAccountResponseDTO(StatusAccount status)
        {
            Id = status.Id;
            Name = status.Name;
            Color = status.Color;
            Icon = status.Icon;
            CreatedAt = status.CreatedAt;
            UpdatedAt = status.UpdatedAt;
        }
    }

    /// <summary>
    /// DTO pour la création d'un nouveau statut de compte
    /// </summary>
    public class StatusAccountCreateDTO
    {
        /// <summary>
        /// Nom du statut
        /// </summary>
        /// <example>Active</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au statut (code hexadécimal)
        /// </summary>
        /// <example>#28a745</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #28a745)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au statut
        /// </summary>
        /// <example>fa-check-circle</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'un statut de compte existant
    /// </summary>
    public class StatusAccountUpdateDTO
    {
        /// <summary>
        /// Nom du statut
        /// </summary>
        /// <example>Active</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au statut (code hexadécimal)
        /// </summary>
        /// <example>#28a745</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #28a745)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au statut
        /// </summary>
        /// <example>fa-check-circle</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        public void UpdateStatusAccount(StatusAccount status)
        {
            status.Name = Name;
            status.Color = Color;
            status.Icon = Icon;
            status.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
