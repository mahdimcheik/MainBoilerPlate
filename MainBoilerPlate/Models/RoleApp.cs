using MainBoilerPlate.Models.Generics;
using Microsoft.AspNetCore.Identity;

namespace MainBoilerPlate.Models
{
    public class RoleApp : IdentityRole<Guid>, IArchivable, ICreatable, IUpdateable
    {
        public DateTimeOffset? ArchivedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string?  Color { get; set; }
        public ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }

    }
}
