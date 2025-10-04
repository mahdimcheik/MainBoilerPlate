using MainBoilerPlate.Models.Generics;

namespace MainBoilerPlate.Models
{
    public class StatusAccount : BaseModelOption
    {
    }

    public class StatusAccountDTO(StatusAccount status)
    {
        public Guid Id => status.Id;
        public string Name => status.Name;
        public string Color => status.Color;
        public string? Icon => status.Icon;


    }
}
