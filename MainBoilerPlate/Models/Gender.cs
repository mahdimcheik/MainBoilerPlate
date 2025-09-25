using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Gender : BaseModel, IArchivable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string? Icon { get; set; }
        public DateTimeOffset? ArchivedAt { get; set; }
    }
}
