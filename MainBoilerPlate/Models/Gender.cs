using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Gender : BaseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string? Icon { get; set; }
    }
}
