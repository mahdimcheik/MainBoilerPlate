using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour l'affichage des informations d'un créneau
    /// </summary>
    public class SlotResponseDTO
    {
        /// <summary>
        /// Identifiant unique du créneau
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Date et heure de début du créneau
        /// </summary>
        /// <example>2023-01-15T10:30:00Z</example>
        [Required]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date et heure de fin du créneau
        /// </summary>
        /// <example>2023-01-15T11:30:00Z</example>
        [Required]
        public DateTimeOffset DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Informations de l'enseignant
        /// </summary>
        public UserResponseDTO? Teacher { get; set; }

        /// <summary>
        /// Identifiant du type de créneau
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required]
        public Guid TypeId { get; set; }

        /// <summary>
        /// Informations du type de créneau
        /// </summary>
        public TypeSlotResponseDTO? Type { get; set; }

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

        /// <summary>
        /// Indique si le créneau est disponible (non réservé)
        /// </summary>
        public bool IsAvailable { get; set; }

        public SlotResponseDTO() { }

        public SlotResponseDTO(Slot slot, bool isAvailable = true)
        {
            Id = slot.Id;
            DateFrom = slot.DateFrom;
            DateTo = slot.DateTo;
            TeacherId = slot.TeacherId;
            TypeId = slot.TypeId;
            CreatedAt = slot.CreatedAt;
            UpdatedAt = slot.UpdatedAt;
            IsAvailable = isAvailable;

            if (slot.Teacher != null)
            {
                Teacher = new UserResponseDTO(slot.Teacher, null);
            }

            if (slot.Type != null)
            {
                Type = new TypeSlotResponseDTO(slot.Type);
            }
        }
    }

    /// <summary>
    /// DTO pour la création d'un nouveau créneau
    /// </summary>
    public class SlotCreateDTO
    {
        /// <summary>
        /// Date et heure de début du créneau
        /// </summary>
        /// <example>2023-01-15T10:30:00Z</example>
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date et heure de fin du créneau
        /// </summary>
        /// <example>2023-01-15T11:30:00Z</example>
        [Required(ErrorMessage = "La date de fin est requise")]
        public DateTimeOffset DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant de l'enseignant est requis")]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Identifiant du type de créneau
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'identifiant du type de créneau est requis")]
        public Guid TypeId { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'un créneau existant
    /// </summary>
    public class SlotUpdateDTO
    {
        /// <summary>
        /// Date et heure de début du créneau
        /// </summary>
        /// <example>2023-01-15T10:30:00Z</example>
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date et heure de fin du créneau
        /// </summary>
        /// <example>2023-01-15T11:30:00Z</example>
        [Required(ErrorMessage = "La date de fin est requise")]
        public DateTimeOffset DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'enseignant
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant de l'enseignant est requis")]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Identifiant du type de créneau
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440002</example>
        [Required(ErrorMessage = "L'identifiant du type de créneau est requis")]
        public Guid TypeId { get; set; }

        public void UpdateSlot(Slot slot)
        {
            slot.DateFrom = DateFrom;
            slot.DateTo = DateTo;
            slot.TeacherId = TeacherId;
            slot.TypeId = TypeId;
            slot.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }

    /// <summary>
    /// DTO pour l'affichage des informations d'un type de créneau
    /// </summary>
    public class TypeSlotResponseDTO
    {
        /// <summary>
        /// Identifiant unique du type de créneau
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Couleur associée au type de créneau (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au type de créneau
        /// </summary>
        /// <example>fa-user</example>
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

        public TypeSlotResponseDTO() { }

        public TypeSlotResponseDTO(TypeSlot typeSlot)
        {
            Id = typeSlot.Id;
            Name = typeSlot.Name;
            Color = typeSlot.Color;
            Icon = typeSlot.Icon;
            CreatedAt = typeSlot.CreatedAt;
            UpdatedAt = typeSlot.UpdatedAt;
        }
    }
}