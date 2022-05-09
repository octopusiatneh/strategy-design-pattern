using StrategyPattern.Models;

namespace StrategyPattern.Factories
{
    public class EmployeeFactory
    {
        public static Employee Create(string fullName, double salary, Classify classify)
        {
            return new Employee
            {
                FullName = fullName,
                Salary = salary,
                Classify = classify,
            };
        }

        public static Employee Create(string fullName, double salary, Classify classify, Nationality nationality)
        {
            return new Employee
            {
                FullName = fullName,
                Salary = salary,
                Classify = classify,
                Nationality = nationality
            };
        }
    }
}
