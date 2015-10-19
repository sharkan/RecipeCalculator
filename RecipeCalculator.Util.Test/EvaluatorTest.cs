using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeCalculator.Util.Test
{
    [TestClass]
    public class EvaluatorTest
    {
        [TestMethod]
        public void TestEvalSuccess( )
        {
            string expression1 = "1/2";
            string expression2 = "3/4";
            string expression3 = "4/4";
            Assert.AreEqual( Evaluator.Eval( expression1 ), 0.5m );
            Assert.AreEqual( Evaluator.Eval( expression2 ), 0.75m );
            Assert.AreEqual( Evaluator.Eval( expression3 ), 1 );
        }

    }
}
