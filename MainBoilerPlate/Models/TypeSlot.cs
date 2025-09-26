using MainBoilerPlate.Models.Generics;
using System.Drawing;

namespace MainBoilerPlate.Models
{
    public class TypeSlot : BaseModel
    {
        public string Name   { get; set; }
        public string Color { get; set; }
        public string? Icon { get; set; }
    }
}
