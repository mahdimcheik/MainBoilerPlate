using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class ProgrammingLanguage : BaseModelOption
    {
        public string? Description { get; set; }
        public ICollection<UserApp> Users { get; set; }
    }
}
