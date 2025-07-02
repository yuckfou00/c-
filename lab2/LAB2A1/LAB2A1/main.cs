namespace Lab2A
{
    /*
  * Your Name: Omar Zahraoui
  * Student Number: 000905815
  * Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
  */
    class Lab2
    {
        /// <summary>
        /// list of the created shapes.
        /// </summary>
        private static List<Shape> shapes = new List<Shape>();

        /// <summary>
        /// displays the menu that allows the user to create various shapes.
        /// </summary>
        public static void Menu()
        {
            while (true)
            {
                // Displays the menu options for shape creation
                Console.WriteLine($"You have created {Shape.GetCount()} shape(s).");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Square");
                Console.WriteLine("3. Box");
                Console.WriteLine("4. Cube");
                Console.WriteLine("5. Ellipse");
                Console.WriteLine("6. Circle");
                Console.WriteLine("7. Cylinder");
                Console.WriteLine("8. Sphere");
                Console.WriteLine("9. Triangle");
                Console.WriteLine("10. Tetrahedron");
                Console.WriteLine("11. Exit");
                Console.Write("Enter your choice: ");

                // Reads the user input and ensures it's valid
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 11)
                {
                    if (choice == 11) break;  

                    Shape shape = null;
                    // Creates a shape based on user choice
                    switch (choice)
                    {
                        case 1: shape = new Rectangle(); break;
                        case 2: shape = new Square(); break;
                        case 3: shape = new Box(); break;
                        case 4: shape = new Cube(); break;
                        case 5: shape = new Ellipse(); break;
                        case 6: shape = new Circle(); break;
                        case 7: shape = new Cylinder(); break;
                        case 8: shape = new Sphere(); break;
                        case 9: shape = new Triangle(); break;
                        case 10: shape = new Tetrahedron(); break;
                    }

                    if (shape != null)
                    {
                        // Prompts the user to enter the shape's dimensions and calculates its properties
                        shape.SetData();
                        shapes.Add(shape);
                        Console.WriteLine($"Shape created: {shape.ToString()}");
                        Console.WriteLine($"Total shapes created: {Shape.GetCount()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please select between 1 and 11.");
                    }
                }
                else
                {
                    // If the input is not valid, prompt the user again
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Menu();  
        }
    }
}
