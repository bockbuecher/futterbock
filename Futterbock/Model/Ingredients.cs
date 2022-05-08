using Futterbock.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futterbock.Model
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public int Unit { get; set; }
    }
}
