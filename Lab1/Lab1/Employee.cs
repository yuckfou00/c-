/**000905815 omar zahraoui certify that this material is my original work no other person's work has been used without due acknowledgement **/

namespace lab1
{
    public class employee
    {
        // Private fields to hold employee details.
        private int number; 
        private string name; 
        private decimal rate; 
        private decimal grow; 
        private double hours; 

        /// <summary>
        /// Constructor to initialize an employee object with given details.
        /// </summary>
        /// <param name="number">Employee ID number</param>
        /// <param name="name">Employee name</param>
        /// <param name="rate">Hourly pay rate</param>
        /// <param name="hours">Hours worked by the employee</param>
        public employee(int number, string name, decimal rate, double hours)
        {
            // Initialize fields with trimmed or provided values
            this.name = name.Trim();
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            culategross(); 
        }

        /// <summary>
        /// This method calculates the employee's gross pay..
        /// </summary>
        public void culategross()
        {
            if (hours <= 40)
            {
                grow = rate * (decimal)hours; 
            }
            else
            {
                // Overtime pay 
                grow = (rate * 40) + (((decimal)hours - 40) * 1.5m * rate);
            }
        }

        /// <summary>
        /// Gets the employee number
        /// </summary>
        /// <returns>Employee number</returns>
        public int getnumber()
        {
            return number;
        }

        /// <summary>
        /// Sets the employee number
        /// </summary>
        /// <param name="number">New employee number</param>
        public void setnumber(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Gets the employee name
        /// </summary>
        /// <returns>Employee name</returns>
        public string getname()
        {
            return name;
        }

        /// <summary>
        /// Sets the employee name
        /// </summary>
        /// <param name="name">New employee name</param>
        public void setname(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// gets the employee hourly pay rate
        /// </summary>
        /// <returns>hourly pay rate</returns>
        public decimal getrate()
        {
            return rate;
        }

        /// <summary>
        /// sets the employee hourly pay rate.
        /// </summary>
        /// <param name="rate">New pay rate</param>
        public void setrate(decimal rate)
        {
            this.rate = rate;
        }

        /// <summary>
        /// gets the employee gross pay.
        /// </summary>
        /// <returns>Gross pay</returns>
        public decimal getgrow()
        {
            return grow;
        }

        /// <summary>
        /// sets the employee gross pay
        /// </summary>
        /// <param name="grow">New gross pay value</param>
        public void setgrow(decimal grow)
        {
            this.grow = grow;
        }

        /// <summary>
        /// gets the number of hours worked
        /// </summary>
        /// <returns>hours worked</returns>
        public double gethours()
        {
            return hours;
        }

        /// <summary>
        /// sets the number of hours worked 
        /// </summary>
        /// <param name="hours">New hours worked</param>
        public void sethours(double hours)
        {
            this.hours = hours;
        }

        /// <summary>
        /// Returns a string representing the employee's data in a tabulated format.
        /// Includes name, number, rate, hours, and gross pay.
        /// </summary>
        /// <returns>A formatted string of the employee's details</returns>
        public override string ToString()
        {
            return $"{name}\t{number}\t{rate:C}\t{hours}\t{grow:C}";
        }
    }

    /// <summary>
    /// The 'lab1' class manages an array of employees. It includes methods for reading employee data from a file, 
    /// sorting the employees by various attributes, and displaying them.
    /// </summary>
    public class lab1
    {
        // Array to hold employee objects, up to a maximum of 100 employees
        employee[] employees = new employee[100];

        // Counter to track how many employees have been loaded
        int employeecount = 0;

        /// <summary>
        /// Reads employee data from a file where each line represents an employee with details separated by commas.
        /// The expected format is: Name,Number,Rate,Hours.
        /// </summary>
        /// <param name="filePath">The path to the employee data file</param>
        public void Read(string filePath)
        {
            try
            {
                // Read all lines from the file
                string[] linesEmpl = File.ReadAllLines(filePath);
                employeecount = 0; // Reset employee count

                // Loop through the file lines, parse the employee data, and store in the employees array
                for (int x = 0; x < linesEmpl.Length && employeecount < 100; x++)
                {
                    string[] parts = linesEmpl[x].Split(',');

                    // Parse the employee details from the file
                    int number = int.Parse(parts[1].Trim());
                    string name = parts[0].Trim();
                    decimal rate = decimal.Parse(parts[2].Trim());
                    double hours = double.Parse(parts[3].Trim());

                    // Create a new employee object and add to the array
                    employees[employeecount++] = new employee(number, name, rate, hours);
                }
                // Confirm loading was successful
                Console.WriteLine($"{employeecount} employees successfully completed loading.");
            }
            catch (Exception ex)
            {
                // Display error message if file reading fails
                Console.WriteLine("Problem encountered while attempting to read the file: " + ex.Message);
            }
        }

        /// <summary>
        /// Sorts the employees by their name in ascending order
        /// </summary>
        public void sortbyname()
        {
            // Sort the employee array based on name
            Array.Sort(employees, 0, employeecount, Comparer<employee>.Create((x, y) => x.getname().CompareTo(y.getname())));
        }

        /// <summary>
        /// Sorts the employees by their id
        /// </summary>
        public void sortbynumber()
        {
            Array.Sort(employees, 0, employeecount, Comparer<employee>.Create((x, y) => x.getnumber().CompareTo(y.getnumber())));
        }

        /// <summary>
        /// sorts the employees by their pay rate
        /// </summary>
        public void sortbyrate()
        {
            Array.Sort(employees, 0, employeecount, Comparer<employee>.Create((x, y) => y.getrate().CompareTo(x.getrate())));
        }

        /// <summary>
        /// Sorts the employees by the number of hours worked
        /// </summary>
        public void sortbyhours()
        {

            Array.Sort(employees, 0, employeecount, Comparer<employee>.Create((x, y) => y.gethours().CompareTo(x.gethours())));
        }

        /// <summary>
        /// sorts the employees by their gross pay
        /// </summary>
        public void sortbygrow()
        {
            Array.Sort(employees, 0, employeecount, Comparer<employee>.Create((x, y) => y.getgrow().CompareTo(x.getgrow())));
        }

        /// <summary>
        /// displays all employee 
        /// </summary>
        public void DisplayEmployees()
        {
            Console.WriteLine("Name\tNumber\tRate\tHours\tGross Pay");

            for (int i = 0; i < employeecount; i++)
            {
                Console.WriteLine(employees[i].ToString());
            }
        }
    }
}
