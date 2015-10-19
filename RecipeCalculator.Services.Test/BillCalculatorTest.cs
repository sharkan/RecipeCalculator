using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeCalculator.Entity;
using RecipeCalculator.Services.Bills;

namespace RecipeCalculator.Services.Test
{
    [TestClass]
    public class BillCalculatorTest
    {

        private RecipeIngredient GetRecipeIngredient(string description, bool isOrganic, decimal price, int type, decimal quantity)
        {
            return new RecipeIngredient
            {
                Ingredient = new Ingredient( )
                {
                    Description = description,
                    IsOrganic = isOrganic,
                    Price = price,
                    Type = type
                } ,
                Quantity = quantity
            };
        }

        [TestMethod]
        public void TestCalculateReceipe2( )
        {
            var list = new List<RecipeIngredient>();
            list.Add( GetRecipeIngredient( "garlic clove", true, 0.67m, 3, 1 ) );
            list.Add( GetRecipeIngredient( "chicken breast", false, 2.19m, 1 , 4 ) );
            list.Add( GetRecipeIngredient( "cup olive oil", false, 1.92m, 2, 0.5m ) );
            list.Add( GetRecipeIngredient( "cup of vinegar", false, 1.26m, 2, 0.5m ) );

            Assert.AreEqual( BillCalculator.CalculateSaleTax(list), 0.91m );
            Assert.AreEqual( BillCalculator.CalculateWellnessDiscount( list ), 0.09m );
            Assert.AreEqual( BillCalculator.CalculateTotal( list ), 11.84m );
        }
    }
}
