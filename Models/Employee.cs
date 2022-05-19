using StrategyPattern.Factories;

namespace StrategyPattern.Models
{
    public class Employee
    {
        private TaxCalculator _taxCalculator => TaxCalculatorFactory.Create();
        
        public string FullName { get; set; }
        public double Salary { get; set; }
        public Classify Classify { get; set; }

        public void Deconstruct(out Classify classify)
        {
            classify = Classify;
        }

        public void Deconstruct(out string fullName, out double salary, out double tax)
        {
            (fullName, salary, tax) = (FullName, Salary, _taxCalculator.CalculateByRecursivePattern(this));
        }
    }
}
