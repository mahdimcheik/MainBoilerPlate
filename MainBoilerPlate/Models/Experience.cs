using MainBoilerPlate.Models.Generics;
using System.ComponentModel.DataAnnotations;

namespace MainBoilerPlate.Models
{
    public class Experience : BaseModel
    {
        [Required]
        required public string Title { get; set; }
        [Required]
        required public string Description { get; set; }

        [Required]
        required public string Institution { get; set; }
        [Required]
        required public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        public Guid UserId { get; set; }
        public UserApp? User { get; set; }
    }
}
