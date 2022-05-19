using StrategyPattern.Models;
using StrategyPattern.Strategies;
using System;
using System.Linq;

namespace StrategyPattern
{
    public partial class TaxCalculator
    {
        private ITaxCalculatorStrategy _strategy;

        public TaxCalculator SetStrategy(ITaxCalculatorStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public double CalculateByStrategyPattern(Employee employee)
        {
            return _strategy.CalculateByStrategyPattern(employee);
        }
    }

    public partial class TaxCalculator
    {
        // Using recursive pattern - C# 8.0
        public double CalculateByRecursivePattern(Employee employee) => employee switch
        {
            var (classify, _) when classify == Classify.Intern => 0,
            var (classify, nationality) when classify == Classify.Official && nationality == Nationality.VN => employee.Salary * 0.1,
            var (classify, nationality) when classify == Classify.Official && nationality == Nationality.US => employee.Salary * 0.2,
            _ => 0
        };

        // Using Property patterns - C# 8.0
        public double CalculateByPropertyPattern(Employee employee) => employee switch
        {
            { Classify: Classify.Intern } => 0,
            { Classify: Classify.Official, Nationality: Nationality.VN } => employee.Salary * 0.1,
            { Classify: Classify.Official, Nationality: Nationality.US } => employee.Salary * 0.2,
            _ => 0
        };

        // Functional programming approach
        public double CalculateByFP(Employee employee) => new (Func<Classify, Nationality, bool?> condition, Func<double, double> calculator)[]
        {
            ((classify, _) => classify == Classify.Intern, salary => 0),
            ((classify, nationality) => classify == Classify.Official && nationality == Nationality.VN, salary => salary * 0.1),
            ((classify, nationality) => classify == Classify.Official && nationality == Nationality.US, salary => salary * 0.2),
        }.First(x => x.condition(employee.Classify, employee.Nationality).HasValue).calculator(employee.Salary);
    }
}