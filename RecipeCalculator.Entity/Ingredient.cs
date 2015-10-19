using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.Entity
{
    public class Ingredient
    {
        public string Description { get; set; }

        public int Type { set; get; }

        public decimal Price { set; get; }

        public bool IsOrganic { set; get; }
    }
}
