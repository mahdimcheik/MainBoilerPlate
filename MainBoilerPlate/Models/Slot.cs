using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Slot : BaseModel
    {
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public Guid TeacherId { get; set; }
        public UserApp Teacher { get; set; }
        public Guid TypeId { get; set; }
        public TypeSlot Type { get; set; }
    }
}
