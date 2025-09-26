using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class Order : BaseModel
    {
        public string OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ReductionPercentage { get; set; }
        public int ReductionAmount { get; set; }
        public Guid StudentId { get; set; }
        public UserApp Student { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
