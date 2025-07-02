using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
 * Your Name: Omar Zahraoui
 * Student Number: 000905815
 * Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
 */

namespace Lab4ANamespace
{
    /// <summary>
    /// Represents an employee with various properties and methods.
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        // Properties replacing fields and Get/Set methods
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public double Hours { get; set; }
        public decimal Gross { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        /// <param name="number">Employee number.</param>
        /// <param name="name">Employee name.</param>
        /// <param name="rate">Pay rate.</param>
        /// <param name="hours">Hours worked.</param>
        public Employee(int number, string name, decimal rate, double hours)
        {
            Number = number;
            Name = name.Trim();
            Rate = rate;
            Hours = hours;
            CalculateGross();
        }

        /// <summary>
        /// Calculates the gross pay.
        /// </summary>
        public void CalculateGross()
        {
            if (Hours <= 40)
                Gross = Rate * (decimal)Hours;
            else
                Gross = (Rate * 40) + (((decimal)Hours - 40) * 1.5m * Rate);
        }

        /// <summary>
        /// Compares the current instance with another Employee object.
        /// </summary>
        /// <param name="other">The Employee to compare with the current instance.</param>
        /// <returns>An integer indicating the relative order of the objects being compared.</returns>
        public int CompareTo(Employee other)
        {
            return Name.CompareTo(other.Name); // Default sort by Name
        }

        /// <summary>
        /// Returns a string that represents the current Employee.
        /// </summary>
        /// <returns>A string representation of the current Employee.</returns>
        public override string ToString()
        {
            return $"{Name}\t{Number}\t{Rate:C}\t{Hours}\t{Gross:C}";
        }
    }

    /// <summary>
    /// The main class for the lab program.
    /// </summary>
    public class Lab1
    {
        private List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Reads employee data from a file.
        /// </summary>
        /// <param name="filePath">The path of the file to read.</param>
        public void Read(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    var employee = new Employee(
                        int.Parse(parts[1].Trim()),
                        parts[0].Trim(),
                        decimal.Parse(parts[2].Trim()),
                        double.Parse(parts[3].Trim())
                    );

                    employees.Add(employee);
                }
                Console.WriteLine($"{employees.Count} employees successfully loaded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem encountered while attempting to read the file: " + ex.Message);
            }
        }

        /// <summary>
        /// Sorts the employee list based on the provided key selector.
        /// </summary>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        public void SortBy(Func<Employee, object> keySelector)
        {
            employees = employees.OrderBy(keySelector).ToList();
        }

        /// <summary>
        /// Displays the list of employees.
        /// </summary>
        public void DisplayEmployees()
        {
            Console.WriteLine("Name\tNumber\tRate\tHours\tGross Pay");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            Lab1 program = new Lab1();
            string fileName = "employees.txt";

            program.Read(fileName);

            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                ProcessChoice(program, choice, ref exit);
            }
        }

        /// <summary>
        /// Displays the menu options.
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Order based on employee names");
            Console.WriteLine("2. Order based on employee number");
            Console.WriteLine("3. Order based on employee Pay Rate");
            Console.WriteLine("4. Order based on employee Hours");
            Console.WriteLine("5. Order based on employee Gross Pay");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
        }

        /// <summary>
        /// Processes the user's menu choice.
        /// </summary>
        /// <param name="program">The Lab1 program instance.</param>
        /// <param name="choice">The user's choice.</param>
        /// <param name="exit">Reference to the exit flag.</param>
        static void ProcessChoice(Lab1 program, string choice, ref bool exit)
        {
            switch (choice)
            {
                case "1":
                    program.SortBy(e => e.Name);
                    program.DisplayEmployees();
                    break;
                case "2":
                    program.SortBy(e => e.Number);
                    program.DisplayEmployees();
                    break;
                case "3":
                    program.SortBy(e => e.Rate);
                    program.DisplayEmployees();
                    break;
                case "4":
                    program.SortBy(e => e.Hours);
                    program.DisplayEmployees();
                    break;
                case "5":
                    program.SortBy(e => e.Gross);
                    program.DisplayEmployees();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}
