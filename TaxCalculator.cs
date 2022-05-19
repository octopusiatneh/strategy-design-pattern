using StrategyPattern.Models;
using StrategyPattern.Strategies;
using System;
using System.Linq;

namespace StrategyPattern
{
    public partial class TaxCalculator
    {
        // Using recursive pattern - C# 8.0
        public double CalculateByRecursivePattern(Employee employee) => employee switch
        {
            var (classify) when classify == Classify.Intern => 0,
            var (classify) when classify == Classify.Official => employee.Salary * 0.1,
            _ => 0
        };

        // Using Property patterns - C# 8.0
        public double CalculateByPropertyPattern(Employee employee) => employee switch
        {
            { Classify: Classify.Intern } => 0,
            { Classify: Classify.Official } => employee.Salary * 0.1,
            _ => 0
        };

        // Functional programming approach
        public double CalculateByFP(Employee employee) => new (Func<Classify, bool?> condition, Func<double, double> calculator)[]
        {
            ((classify) => classify == Classify.Intern, salary => 0),
            ((classify) => classify == Classify.Official, salary => salary * 0.1)
        }.First(x => x.condition(employee.Classify).HasValue).calculator(employee.Salary);
    }
}