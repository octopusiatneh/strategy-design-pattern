using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StrategyPattern.Factories;
using StrategyPattern.Models;
using System;

namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuidler();
            host.Services
                    .GetRequiredService<Program>()
                    .Execute(args);

            Console.ReadKey();
        }

        private void Execute(string[] args)
        {
            var employees = new[]
            {
                EmployeeFactory.Create(fullName: "Tran Van A", salary: 500, Classify.Official),
                EmployeeFactory.Create(fullName: "Nguyen Thi B", salary: 1_000, Classify.Official),
                EmployeeFactory.Create(fullName: "Tran Van C", salary: 200, Classify.Intern)
            };

            Array.ForEach(employees, PrintEmployeeInformation);
        }

        private static void PrintEmployeeInformation(Employee employee)
        {
            var (fullName, salary, tax) = employee;
            Console.WriteLine(" ".PadRight(53, '-'));
            Console.WriteLine(String.Format("| {0,-20} | {1,-10} | {2,-14} |", "Full Name", "Salary", "Tax"));
            Console.WriteLine(String.Format("| {0,-20} | {1,-10} | {2,-14} |", fullName, salary, tax));
            Console.WriteLine(" ".PadRight(53, '-'));
        }

        private static IHost CreateHostBuidler()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Program>();
                })
                .Build();

            return hostBuilder;
        }
    }
}
