using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models.Generics
{
    public class BaseModelOption : BaseModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Color { get; set; }
        public string? Icon { get; set; }
    }
}
