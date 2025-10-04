using System.ComponentModel.DataAnnotations;
using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class StatusAccount : BaseModelOption { }

    public class StatusAccountDTO(StatusAccount status)
    {
        [Required]
        public Guid Id => status.Id;
        [Required]
        public string Name => status.Name;
        [Required]
        public string Color => status.Color;
        public string? Icon => status.Icon;
    }
}
