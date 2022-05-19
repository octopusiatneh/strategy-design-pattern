using StrategyPattern.Factories;

namespace StrategyPattern.Models
{
    public class Employee
    {
        private TaxCalculator _taxCalculator => TaxCalculatorFactory.Create(this);
        
        public string FullName { get; set; }
        public double Salary { get; set; }
        public Classify Classify { get; set; }
        public Nationality Nationality { get; set; }

        public void Deconstruct(out Classify classify, out Nationality nationality)
        {
            (classify, nationality) = (Classify, Nationality);
        }

        public void Deconstruct(out string fullName, out double salary, out double tax)
        {
            (fullName, salary, tax) = (FullName, Salary, _taxCalculator.CalculateByStrategyPattern(this));
        }
    }
}
