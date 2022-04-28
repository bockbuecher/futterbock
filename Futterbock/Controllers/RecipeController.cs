using Futterbock.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Futterbock.Model;

namespace Futterbock.Controllers
{
    public class RecipeController : ControllerBase
    {
        private IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }


        //Hier ggf. den richtigen Path eintragen
        [HttpPost("recipe/createrecipe")]
        public void CreateRecipe(Recipe recipe)
        {
            _service.CreateRecipe(recipe);
        }
    }
}
