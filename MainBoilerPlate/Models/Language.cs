using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Language : BaseModelOption
    {
        public ICollection<UserApp>? Users { get; set; }
    }
}
