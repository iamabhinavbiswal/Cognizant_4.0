using SingletonPatternExample.SingletonPatternExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern:\n");

            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            logger1.Log("HI! THIS IS ABHINAV BISWAL.");
            logger2.Log("Kalinga Institute of Industrial Technology.");

            if (logger1 == logger2)
            {
                Console.WriteLine("\nBoth logger1 and logger2 are the same instance.");
            }
            else
            {
                Console.WriteLine("\nDifferent instances detected! Singleton failed.");
            }
        }
    }
}