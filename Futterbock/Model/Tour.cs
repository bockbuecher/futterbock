using System;
using System.ComponentModel.DataAnnotations;

namespace Futterbock.Model
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public MealCategory Startmeal { get; set; }
        public MealCategory Endmeal { get; set; }
    }
}
