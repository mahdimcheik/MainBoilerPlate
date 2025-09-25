using MainBoilerPlate.Models.Generics;
using Microsoft.AspNetCore.Identity;

namespace MainBoilerPlate.Models
{
    public class RoleApp : IdentityRole<Guid>, IArchivable, ICreatable
    {
        public DateTimeOffset? ArchivedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
