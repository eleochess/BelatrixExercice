using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExercice
{
    public class Prueba
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        enum EnumTest { TestOne = 1, TestTwo = 2, TestThree = 3 }

        static void Main()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);

            string asdf = EnumTest.TestOne.ToString();
        }
    }
}
