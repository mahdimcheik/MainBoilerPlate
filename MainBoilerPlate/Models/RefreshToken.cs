using MainBoilerPlate.Models.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainBoilerPlate.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string? Token { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public Guid? UserId { get; set; }
        public UserApp? User { get; set; }
    }
}
