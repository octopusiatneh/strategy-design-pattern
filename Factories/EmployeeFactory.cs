using StrategyPattern.Models;

namespace StrategyPattern.Factories
{
    public class EmployeeFactory
    {
        public static Employee Create(string fullName, double salary)
        {
            return new Employee
            {
                FullName = fullName,
                Salary = salary
            };
        }
    }
}
