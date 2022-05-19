using StrategyPattern.Models;

namespace StrategyPattern
{
    public partial class TaxCalculator
    {
        public double Calculate(Employee employee) => employee.Salary * 0.1;
    }
}