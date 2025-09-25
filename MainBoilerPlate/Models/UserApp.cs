using System.ComponentModel.DataAnnotations.Schema;
using MainBoilerPlate.Models.Generics;
using Microsoft.AspNetCore.Identity;

namespace MainBoilerPlate.Models
{
    public class UserApp : IdentityUser<Guid>, IArchivable, IUpdateable, ICreatable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? ArchivedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;

        //gender
        public Guid? GenderId { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; }

        // address
        public ICollection<Address>? Adresses { get; set; }
    }
}
