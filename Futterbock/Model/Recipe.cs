using System.Collections.Generic;

namespace Futterbock.Model
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public List<Ingredients> ingredients { get; set; }
    }
}
