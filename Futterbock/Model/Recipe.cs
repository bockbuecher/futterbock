using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Futterbock.Model
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
