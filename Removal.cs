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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronScales
{
    public class Removal
    {
        public static String Remove(string text)
        {
            Console.WriteLine("Original string: " + text);
            Console.WriteLine("Length before: " + text.Length);
            Console.WriteLine("Trimmed version: " + text.Trim());
            Console.WriteLine("Length after: " + text.Trim().Length);
            return text.Trim();
        }
    }
}

