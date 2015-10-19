using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeCalculator.Entity;
using RecipeCalculator.Services.Bills;
using RecipeCalculator.Services.Ingredients;
using RecipeCalculator.Services.Recipes;

namespace RecipeCalculator
{
    class Program
    {
        private void DisplayBill(List<RecipeIngredient> recipeItems)
        {
            Console.WriteLine("Recipe");
            foreach (var x in recipeItems)
            {
                Console.WriteLine(x.Quantity + " " + x.Ingredient.Description);
            }
            var saleTax = BillCalculator.CalculateSaleTax(recipeItems);
            var discount = BillCalculator.CalculateWellnessDiscount(recipeItems);
            var total = BillCalculator.CalculateTotal(recipeItems) + saleTax - discount;
            Console.WriteLine("Tax: " + String.Format("{0}", saleTax));
            Console.WriteLine("Discount: " + String.Format( "{0:0.##}", discount));
            Console.WriteLine("Total: " + String.Format("{0:0.##}", total));
        }

        public void Run()
        {
            List<Ingredient> ingredients = IngredientsReader.GetIngredients();
            RecipeReader recipeReader = new RecipeReader(ingredients);
            List<RecipeIngredient> recipeIngredients = recipeReader.GetRecipeIngredients();
            
            DisplayBill( recipeIngredients );
        }

        static void Main( string[] args )
        {
            Program program = new Program();
            program.Run();
            Console.ReadLine();
        }
    }
}
