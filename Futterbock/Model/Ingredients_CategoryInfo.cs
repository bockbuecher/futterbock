using Futterbock.Enum;
using System.ComponentModel.DataAnnotations;

namespace Futterbock.Model
{
    public class Ingredients_CategoryInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get;set; }
        public FoodTypes Category { get;set;}
        public Ingredients Ingredient { get; set; }

    }
}
