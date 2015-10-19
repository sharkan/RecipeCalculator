using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.DB
{
    public class DBConstants
    {
        public const string InputIngredientsDb = "c:\\temp\\ingredients.csv";
        public const string InputIngredientRecipeDb = "c:\\temp\\recipe.csv";

        public const char InputIngredientsDbSeparator = ',';

        public const int InputIngredientsDbRecordsPerRow = 4;
        public const int InputIngredientRecipeDbRecordsPerRow = 2;

        public const int IngredientTypePosition = 1;
        public const int IngredientDescriptionPosition = 2;
        public const int IngredientPricePosition = 3;
        public const int IngredientOrganicPosition = 4;


        public const int IngredientQuantityPosition = 1;
    }
}
