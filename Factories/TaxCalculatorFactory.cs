using StrategyPattern.Models;
using StrategyPattern.Strategies;

namespace StrategyPattern.Factories
{
    public class TaxCalculatorFactory
    {
        private static TaxCalculator _taxCalculator => new TaxCalculator();
        private static InternEmployeeTaxCalculator _internEmployeeTaxCalculator => new InternEmployeeTaxCalculator();
        private static OfficalEmployeeTaxCalculator _officalEmployeeTaxCalculator => new OfficalEmployeeTaxCalculator();
        
        public static TaxCalculator Create(Employee employee) => employee switch
        {
            { Classify: Classify.Intern } => _taxCalculator.SetStrategy(_internEmployeeTaxCalculator),
            { Classify: Classify.Official } => _taxCalculator.SetStrategy(_officalEmployeeTaxCalculator),
            _ => _taxCalculator
        };
    }
}
