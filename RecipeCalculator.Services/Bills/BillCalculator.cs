using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeCalculator.Entity;

namespace RecipeCalculator.Services.Bills
{
    public static class BillCalculator
    {
        public const decimal NonProduceTax = 8.6m;
        public const decimal WellnessDiscount = 0.5m;

        public static decimal CalculateTotal(List<RecipeIngredient> receipeItems)
        {
            var total = receipeItems.Sum(item => item.Quantity*item.Ingredient.Price);
            return total;
        }

        public static decimal CalculateSaleTax(List<RecipeIngredient> receipeItems)
        {
            var totalNonProduce = receipeItems.Where( item => item.Ingredient.Type != (int)IngredientType.Produce ).Sum( item => NonProduceTax * item.Quantity * item.Ingredient.Price / 100);
            return totalNonProduce;
        }

        public static decimal CalculateWellnessDiscount(List<RecipeIngredient> receipeItems)
        {
            var totalWellnes = receipeItems.Where( item => item.Ingredient.IsOrganic ).Sum( item => WellnessDiscount * item.Quantity * item.Ingredient.Price / 100 );
            return totalWellnes;
        }
    }
}