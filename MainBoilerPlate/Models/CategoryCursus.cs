using MainBoilerPlate.Models.Generics;
using System.Collections.ObjectModel;

namespace MainBoilerPlate.Models
{
    public class CategoryCursus : BaseModelOption
    {
        public Collection<Cursus> Cursuses { get; set; }
    }
}
