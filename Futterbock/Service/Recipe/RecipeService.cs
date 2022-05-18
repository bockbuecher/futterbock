using Futterbock.Context;
using Futterbock.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
#nullable enable
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
            
        }

        public IEnumerable<Recipe> SearchRecipe(string searchTern)
        {
            return _context.Recipe
                .Where(
                    x => x.Name.Contains(searchTern) || 
                    x.Description.StartsWith(searchTern))
                .ToList();
        }

        public Recipe? ViewRecipe(int id) => _context.Recipe.FirstOrDefault(x => x.ID == id);
    }
}
