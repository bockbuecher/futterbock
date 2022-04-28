using Futterbock.Context;
using Futterbock.Model;
using Microsoft.Extensions.Logging;

namespace Futterbock.Service.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly FutterbockContext _context;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(FutterbockContext context, ILogger<RecipeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void CreateRecipe(Recipe recipe)
        {
            if (_context.Entry(recipe).IsKeySet && recipe.ingredients.Count > 0)
            {
                _context.Recipes.Add(recipe);
            }
            else
            {
                _logger.LogError($"Das Rezept hat keine ID oder keine Zutaten. Bitte überprüfe deine Eingabe");
            }

            _context.SaveChanges();
        }
    }
}
