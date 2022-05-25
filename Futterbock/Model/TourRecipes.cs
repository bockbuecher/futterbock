using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Futterbock.Model
{
    public class TourRecipes
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Keine Tour ID angegeben")]
        public Tour Tour { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
    }
}
