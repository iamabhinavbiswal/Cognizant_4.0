using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialForecasting
{
    class Program
    {
        static Dictionary<int, double> memo = new Dictionary<int, double>();

        static void Main(string[] args)
        {
            Console.WriteLine("Optimized Financial Forecasting Tool");

            Console.Write("Enter initial investment amount: ");
            double initialValue = double.Parse(Console.ReadLine());

            Console.Write("Enter annual growth rate (%): ");
            double growthRate = double.Parse(Console.ReadLine()) / 100;

            Console.Write("Enter number of years to forecast: ");
            int years = int.Parse(Console.ReadLine());

            double futureValue = ForecastMemo(initialValue, growthRate, years);

            Console.WriteLine($"Forecasted value after {years} years: {futureValue:C2}");
        }

        static double ForecastMemo(double currentValue, double growthRate, int year)
        {
            if (year == 0)
                return currentValue;

            if (memo.ContainsKey(year))
                return memo[year];

            double result = ForecastMemo(currentValue, growthRate, year - 1) * (1 + growthRate);
            memo[year] = result;
            return result;
        }
    }
}