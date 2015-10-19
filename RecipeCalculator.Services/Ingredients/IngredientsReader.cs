using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using RecipeCalculator.DB;
using RecipeCalculator.Entity;

namespace RecipeCalculator.Services.Ingredients
{

    public static class IngredientsReader
    {


        public static List<Ingredient> GetIngredients()
        {
            string[] ingredientsList = File.ReadAllLines(DBConstants.InputIngredientsDb);
            var ingredientList = new List<Ingredient>();
            foreach (var ing in ingredientsList)
            {
                var raw = ing.Split( DBConstants.InputIngredientsDbSeparator );
                if (raw.Length != DBConstants.InputIngredientsDbRecordsPerRow)
                    continue;
                try
                {
                    var ingredient = new Ingredient
                    {
                        Type = Convert.ToInt32( raw[DBConstants.IngredientTypePosition - 1] ),
                        Description = raw[DBConstants.IngredientDescriptionPosition - 1],
                        Price = Convert.ToDecimal( raw[DBConstants.IngredientPricePosition - 1] ),
                        IsOrganic = "Organic".Equals(raw[DBConstants.IngredientOrganicPosition -1], StringComparison.InvariantCultureIgnoreCase)
                    };
                    ingredientList.Add(ingredient);
                }
                catch
                {
                    Console.WriteLine("Error processing row: " + ing);
                }
            }
            return ingredientList;
        }

        public static Ingredient GetIngredientByDescription(List<Ingredient> ingredients, string ingredient)
        {
            if (string.IsNullOrEmpty(ingredient) || ingredients == null || ingredients.Count == 0)
            {
                return null;
            }
            foreach (var ingr in ingredients)
            {
                if (ingredient.Equals(ingr.Description, StringComparison.InvariantCultureIgnoreCase))
                {
                    return ingr;
                }
            }
            return null;
        }
    }
}
