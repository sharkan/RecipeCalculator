using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeCalculator.DB;
using RecipeCalculator.Entity;
using RecipeCalculator.Services.Ingredients;
using RecipeCalculator.Util;

namespace RecipeCalculator.Services.Recipes
{
    public class RecipeReader
    {
        private List<Ingredient> _ingredients = null; 



        public RecipeReader(List<Ingredient> ingredients)
        {
            _ingredients = ingredients;
        }

        public List<RecipeIngredient> GetRecipeIngredients()
        {
            string[] ingredientsList = File.ReadAllLines( DBConstants.InputIngredientRecipeDb );
            var ingredientList = new List<RecipeIngredient>( );
            foreach (var ing in ingredientsList)
            {
                var raw = ing.Split( DBConstants.InputIngredientsDbSeparator );
                if (raw.Length != DBConstants.InputIngredientRecipeDbRecordsPerRow)
                    continue;
                try
                {
                    var ingredient = new RecipeIngredient
                    {
                        Ingredient = IngredientsReader.GetIngredientByDescription( _ingredients, raw[DBConstants.IngredientDescriptionPosition - 1] ),
                        Quantity = Evaluator.Eval( raw[DBConstants.IngredientQuantityPosition - 1] )
                    };
                    ingredientList.Add( ingredient );
                }
                catch
                {
                    Console.WriteLine( "Error processing row: " + ing );
                }
            }
            return ingredientList;
        }
    }
}
