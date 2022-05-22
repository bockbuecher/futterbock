using Futterbock.Context;
using Futterbock.Model;
using System.Collections.Generic;
using System.Linq;

namespace Futterbock.Repository
{
    public class IngredientsRepository
    {
        private readonly FutterbockContext _context;

        public HashSet<Ingredients> Ingredients;

        public IngredientsRepository(FutterbockContext context)
        {
            _context = context;
            GetValues();
        }

        void GetValues()
        {
            Ingredients = _context.Ingredients.ToHashSet();
        }
    }
}
