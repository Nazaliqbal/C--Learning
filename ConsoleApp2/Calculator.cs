using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Calculator
    {
        public static double Calculate(double firstNo, double secondNo, string operatorName)
        {
            double result = 0;

            switch (operatorName)
            {
                case "+":
                    result = firstNo + secondNo;
                    break;
                case "-":
                    result = firstNo - secondNo;
                    break;
                case "*":
                    result = firstNo * secondNo;
                    break;
                case "/":
                    result = firstNo / secondNo;
                    break;
                default:
                    Console.WriteLine("Invalid operator entered.");
                    break;
            }

            return result;
        }
    }
}
