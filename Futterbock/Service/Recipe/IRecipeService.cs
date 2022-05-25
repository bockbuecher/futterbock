using Futterbock.Model;
using System.Collections.Generic;
#nullable enable
namespace Futterbock.Service.Service
{
    public interface IRecipeService
    {
        public void CreateRecipe(Recipe recipe);

        public Recipe? ViewRecipe(int id);

        public IEnumerable<Recipe> SearchRecipe(string searchTern);

    }
}
