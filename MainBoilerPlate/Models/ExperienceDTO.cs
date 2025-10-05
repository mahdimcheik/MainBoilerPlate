using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    /// <summary>
    /// DTO pour l'affichage des informations d'une expérience
    /// </summary>
    public class ExperienceResponseDTO
    {
        /// <summary>
        /// Identifiant unique de l'expérience
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Titre du poste/expérience
        /// </summary>
        /// <example>Développeur Full Stack</example>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Description détaillée de l'expérience
        /// </summary>
        /// <example>Développement d'applications web avec React et .NET Core</example>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Entreprise/Institution où l'expérience a été acquise
        /// </summary>
        /// <example>TechCorp Solutions</example>
        [Required]
        public string Institution { get; set; }

        /// <summary>
        /// Date de début de l'expérience
        /// </summary>
        /// <example>2021-01-15T00:00:00Z</example>
        [Required]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date de fin de l'expérience (optionnelle si en cours)
        /// </summary>
        /// <example>2023-12-31T00:00:00Z</example>
        public DateTimeOffset? DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur associé
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required]
        public Guid UserId { get; set; }

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

        public ExperienceResponseDTO() { }

        public ExperienceResponseDTO(Experience experience)
        {
            Id = experience.Id;
            Title = experience.Title;
            Description = experience.Description;
            Institution = experience.Institution;
            DateFrom = experience.DateFrom;
            DateTo = experience.DateTo;
            UserId = experience.UserId;
            CreatedAt = experience.CreatedAt;
            UpdatedAt = experience.UpdatedAt;
        }
    }

    /// <summary>
    /// DTO pour la création d'une nouvelle expérience
    /// </summary>
    public class ExperienceCreateDTO
    {
        /// <summary>
        /// Titre du poste/expérience
        /// </summary>
        /// <example>Développeur Full Stack</example>
        [Required(ErrorMessage = "Le titre est requis")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères")]
        public string Title { get; set; }

        /// <summary>
        /// Description détaillée de l'expérience
        /// </summary>
        /// <example>Développement d'applications web avec React et .NET Core</example>
        [Required(ErrorMessage = "La description est requise")]
        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères")]
        public string Description { get; set; }

        /// <summary>
        /// Entreprise/Institution où l'expérience a été acquise
        /// </summary>
        /// <example>TechCorp Solutions</example>
        [Required(ErrorMessage = "L'institution est requise")]
        [StringLength(200, ErrorMessage = "L'institution ne peut pas dépasser 200 caractères")]
        public string Institution { get; set; }

        /// <summary>
        /// Date de début de l'expérience
        /// </summary>
        /// <example>2021-01-15T00:00:00Z</example>
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date de fin de l'expérience (optionnelle si en cours)
        /// </summary>
        /// <example>2023-12-31T00:00:00Z</example>
        public DateTimeOffset? DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur associé
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant utilisateur est requis")]
        public Guid UserId { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'une expérience existante
    /// </summary>
    public class ExperienceUpdateDTO
    {
        /// <summary>
        /// Titre du poste/expérience
        /// </summary>
        /// <example>Développeur Full Stack</example>
        [Required(ErrorMessage = "Le titre est requis")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères")]
        public string Title { get; set; }

        /// <summary>
        /// Description détaillée de l'expérience
        /// </summary>
        /// <example>Développement d'applications web avec React et .NET Core</example>
        [Required(ErrorMessage = "La description est requise")]
        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères")]
        public string Description { get; set; }

        /// <summary>
        /// Entreprise/Institution où l'expérience a été acquise
        /// </summary>
        /// <example>TechCorp Solutions</example>
        [Required(ErrorMessage = "L'institution est requise")]
        [StringLength(200, ErrorMessage = "L'institution ne peut pas dépasser 200 caractères")]
        public string Institution { get; set; }

        /// <summary>
        /// Date de début de l'expérience
        /// </summary>
        /// <example>2021-01-15T00:00:00Z</example>
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Date de fin de l'expérience (optionnelle si en cours)
        /// </summary>
        /// <example>2023-12-31T00:00:00Z</example>
        public DateTimeOffset? DateTo { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur associé
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440001</example>
        [Required(ErrorMessage = "L'identifiant utilisateur est requis")]
        public Guid UserId { get; set; }
    }
}