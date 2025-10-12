using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour la création d'un nouveau type de créneau
    /// </summary>
    public class TypeSlotCreateDTO
    {
        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au type de créneau (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au type de créneau
        /// </summary>
        /// <example>fa-user</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'un type de créneau existant
    /// </summary>
    public class TypeSlotUpdateDTO
    {
        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au type de créneau (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au type de créneau
        /// </summary>
        /// <example>fa-user</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        public void UpdateTypeSlot(TypeSlot typeSlot)
        {
            typeSlot.Name = Name;
            typeSlot.Color = Color;
            typeSlot.Icon = Icon;
            typeSlot.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}