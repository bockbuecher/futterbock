using Futterbock.Enum;

namespace Futterbock.Model
{
    public class Ingredients
    {
        public int IngredientsID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public FoodTypes FoodType { get; set; }
        public int RecipeID { get; set; }
    }
}
