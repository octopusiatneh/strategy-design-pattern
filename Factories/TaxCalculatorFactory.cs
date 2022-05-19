using StrategyPattern.Models;
using StrategyPattern.Strategies;

namespace StrategyPattern.Factories
{
    public class TaxCalculatorFactory
    {
        private static TaxCalculator _taxCalculator => new TaxCalculator();
        public static TaxCalculator Create() => _taxCalculator;
    }
}
