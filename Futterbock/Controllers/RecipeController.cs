using Futterbock.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Futterbock.Model;
using System.Collections.Generic;

#nullable enable
namespace Futterbock.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }


        //Hier ggf. den richtigen Path eintragen
        [HttpPost]
        public void CreateRecipe(Recipe recipe)
        {
            _service.CreateRecipe(recipe);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Search(string searchTern)
        {
            return Ok(_service.SearchRecipe(searchTern));
        }

        [HttpGet]
        public ActionResult<Recipe> View(int id)
        {
            var recipe = _service.ViewRecipe(id);
            return recipe == null 
                ? NotFound(id)
                : Ok(recipe);
        }
    }
}
