/**000905815 omar zahraoui certify that this material is my original work.  No other person's work has been used without due acknowledgement **/
namespace lab1
{
    /** main emthod **/
    public class work { 
    static void Main(string[] args)
    {
        lab1 program = new lab1();

        string fileName = "employees.txt";

        program.Read(fileName);

        bool exit = false;
        while (!exit)
        {
            /** menu to choose a choice **/
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1.order based on employee names");
            Console.WriteLine("2.order based on employee number");
            Console.WriteLine("3.order based on employee Pay Rate");
            Console.WriteLine("4.order based on employee Hours");
            Console.WriteLine("5.order based on employee Gross Pay");
            Console.WriteLine("6.Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            /** switch case depend what the user has choice **/
            switch (choice)
            {
                case "1":
                    /** Call the method sort by name **/
                    program.sortbyname();
                    /** Call the method dispaly the employee **/
                    program.DisplayEmployees();
                    break;
                case "2":
                    /** Call the method sort by number **/
                    program.sortbynumber();
                    /** Call the method dispaly the employee **/
                    program.DisplayEmployees();
                    break;
                case "3":
                    /** Call the method sort by rate **/
                    program.sortbyrate();
                    /** Call the method dispaly the employee **/
                    program.DisplayEmployees();
                    break;
                case "4":
                    /** Call the method sort by hours **/
                    program.sortbyhours();
                    /** Call the method dispaly the employee **/
                    program.DisplayEmployees();
                    break;
                case "5":
                    /** Call the method sort by grow **/
                    program.sortbygrow();
                    /** Call the method dispaly the employee **/
                    program.DisplayEmployees();
                    break;
                case "6":
                    /** EXIT **/
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    /** Dislay a message when the user write a invalid number **/
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
    }

}
