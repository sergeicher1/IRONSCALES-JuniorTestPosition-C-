/*
------------------------------------------------------------------------------------------------
-- coding                                   | utf-8
-- Author                                   | Sergei Chernyahovsky
-- Site                                     | http://sergeicher.pro/
-- Favorite Quote                           | “Always code as if the guy who ends up
                                                maintaining your code will be a violent
                                                    psychopath who knows where you live”
-- Language                                 | C#
-- Description                              | QA automation Junior position test - C#
------------------------------------------------------------------------------------------------
 */


using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronScales
{
    public class TestRemoval
    {
        [Test]

        public void TestCase1Positive()
        {
            Console.WriteLine("\nPositive tests: \n");

            Assert.AreEqual("Hello World!", Removal.Remove(" Hello World!"), "The strings don't match: ");


            Assert.AreEqual("Hello World!", Removal.Remove("Hello World! "), "The strings don't match: ");

            Assert.AreEqual("Hello World!", Removal.Remove(" Hello World! "), "The strings don't match: ");
            


        }


        [Test]
        public void TestCase2Negative()
        {
            Console.WriteLine("\nNegative tests: \n");

            Assert.AreEqual("", Removal.Remove(""), "The strings don't match: ");

            Assert.AreEqual("", Removal.Remove(" "), "The strings don't match: ");

            Assert.AreEqual("a b", Removal.Remove("a b"), "The strings don't match: ");

            Assert.AreEqual("a b c", Removal.Remove("a b c"), "The strings don't match: ");

            Assert.AreEqual("!@#$%^&*()_+-=", Removal.Remove("!@#$%^&*()_+-="), "The strings don't match: ");

            Assert.AreEqual("Hello World!", Removal.Remove("      Hello World!      "), "The strings don't match: ");

            Assert.AreEqual("תודה מכל הלב!", Removal.Remove("      תודה מכל הלב!      "), "The strings don't match: ");


        }
    }
}
