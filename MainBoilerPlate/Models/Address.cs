using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Address : BaseModel
    {
        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string State { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required string ZipCode { get; set; }
        public string? AdditionalInfo { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserApp User { get; set; }
    }
}
