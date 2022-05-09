using StrategyPattern.Models;

namespace StrategyPattern.Strategies
{
    public interface ITaxCalculatorStrategy
    {
        public double CalculateStrategyPattern(Employee employee);
    }

    public class InternEmployeeTaxCalculator : ITaxCalculatorStrategy
    {
        public double CalculateStrategyPattern(Employee employee) => 0;
    }

    public class OfficalEmployeeTaxCalculator : ITaxCalculatorStrategy
    {
        public double CalculateStrategyPattern(Employee employee) => employee switch
        {
            { Classify: Classify.Official, Nationality: Nationality.VN } => CalculateTaxForAsianEmployee(employee.Salary),
            { Classify: Classify.Official, Nationality: Nationality.US } => CalculateTaxForAmericaEmployee(employee.Salary),
            _ => 0
        };

        private double CalculateTaxForAsianEmployee(double salary) => salary * 0.1;

        private double CalculateTaxForAmericaEmployee(double salary) => salary * 0.2;
    }
}
