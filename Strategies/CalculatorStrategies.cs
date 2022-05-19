using StrategyPattern.Models;
using System.Collections.Generic;

namespace StrategyPattern.Strategies
{
    public interface ITaxCalculatorStrategy
    {
        public double CalculateByStrategyPattern(Employee employee);
    }

    public class CalculateTaxByIndividualContinents
    {
        protected readonly List<Nationality> AsianNationalities = new List<Nationality> { Nationality.VN };

        protected readonly List<Nationality> AmericaNationalities = new List<Nationality> { Nationality.US, Nationality.MEX };

        protected readonly List<Nationality> EuropeNationalities = new List<Nationality> { Nationality.UK, Nationality.FR };

        protected double CalculateTaxForAsianEmployee(double salary) => salary * 0.1;

        protected double CalculateTaxForAmericaEmployee(double salary) => salary * 0.2;

        protected double CalculateTaxForEuropeEmployee(double salary) => salary * 0.3;
    }

    public class InternEmployeeTaxCalculator : ITaxCalculatorStrategy
    {
        public double CalculateByStrategyPattern(Employee employee) => 0;
    }

    public class OfficalEmployeeTaxCalculator : CalculateTaxByIndividualContinents, ITaxCalculatorStrategy
    {
        public double CalculateByStrategyPattern(Employee employee) => employee switch
        {
            var (_, nationality) when AsianNationalities.Contains(nationality) => CalculateTaxForAsianEmployee(employee.Salary),
            var (_, nationality) when AmericaNationalities.Contains(nationality) => CalculateTaxForAmericaEmployee(employee.Salary),
            var (_, nationality) when EuropeNationalities.Contains(nationality) => CalculateTaxForEuropeEmployee(employee.Salary),
            _ => 0
        };


    }
}
