using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.Entity
{
    public class RecipeIngredient
    {
        public decimal Quantity { set; get; }
        public Ingredient Ingredient { set; get; }
    }
}
