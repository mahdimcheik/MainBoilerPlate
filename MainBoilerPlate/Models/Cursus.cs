using MainBoilerPlate.Models.Generics;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainBoilerPlate.Models
{
    public class Cursus : BaseModelOption
    {
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public Guid LevelId { get; set; }
        public LevelCursus? Level { get; set; }
        public Guid TeacherId { get; set; }
        public UserApp? Teacher { get; set; }
        public ICollection<CategoryCursus> Categories { get; set; }
    }
}
