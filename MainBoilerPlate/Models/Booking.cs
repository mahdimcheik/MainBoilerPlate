using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Booking : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid SlotId { get; set; }
        public Slot Slot { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid StudentId { get; set; }
        public UserApp Student { get; set; }
    }
}
