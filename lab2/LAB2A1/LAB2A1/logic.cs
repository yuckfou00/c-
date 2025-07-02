namespace Lab2A
{
 /*
* Your Name: Omar Zahraoui
* Student Number: 000905815
* Statement of Authorship: I, Omar Zahraoui, certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/
    /// <summary>
    /// abstract base class representing a general Shape.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// describes the type of the shape
        /// </summary>
        public string Type { get; protected set; }         
        private static int count = 0;                     
        protected const double PI = 3.141592653589793;
        /// <summary>
        /// constructor for the Shape class
        /// </summary>
        public Shape()
        {
            count++;
        }
        /// <summary>
        /// method to calculate the area of the shape
        /// </summary>
        /// <returns>The calculated area of the shape </returns>
        public abstract double CalculateArea();
        // <summary>
        ///method to calculate the volume of the shape
        /// </summary>
        /// <returns>The calculated volume of the shape </returns>

        public abstract double CalculateVolume();
        /// <summary>
        /// method to set the data of the shape
        /// </summary>
        public abstract void SetData();

        public override string ToString() => "";

        /// <summary>
        /// method to get the count of Shape 
        /// </summary>
        /// <returns>total number of Shapes created</returns>
        public static int GetCount()
        {
            return count;
        }
    }
    // Rectangle class and locgic
    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle()
        {
            Type = "Rectangle";
        }

        public override void SetData()
        {
            Console.Write("Enter the length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Enter the width: ");
            width = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return length * width;
        }

        public override double CalculateVolume()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{Type}: Length = {length}, Width = {width}, Area = {CalculateArea()}";
        }
    }

    // square class and locgic
    public class Square : Shape
    {
        private double side;

        public Square()
        {
            Type = "Square";
        }

        public override void SetData()
        {
            Console.Write("Enter the side: ");
            side = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return side * side;
        }

        public override double CalculateVolume()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{Type}: Side = {side}, Area = {CalculateArea()}";
        }
    }

    // box class and locgic
    public class Box : Shape
    {
        private double width;
        private double height;
        private double length;

        public Box()
        {
            Type = "Box";
        }

        public override void SetData()
        {
            Console.Write("Enter the length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Enter the width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Enter the height: ");
            height = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return 2 * (length * width + length * height + height * width);
        }

        public override double CalculateVolume()
        {
            return length * width * height;
        }

        public override string ToString()
        {
            return $"{Type}: Length = {length}, Width = {width}, Height = {height}, Surface Area = {CalculateArea()}, Volume = {CalculateVolume()}";
        }
    }

    // cube class and locgic
    public class Cube : Shape
    {
        private double side;

        public Cube()
        {
            Type = "Cube";
        }

        public override void SetData()
        {
            Console.Write("Enter the side: ");
            side = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return 6 * side * side;
        }

        public override double CalculateVolume()
        {
            return side * side * side;
        }

        public override string ToString()
        {
            return $"{Type}: Side = {side}, Surface Area = {CalculateArea()}, Volume = {CalculateVolume()}";
        }
    }

    // ellipse class and locgic
    public class Ellipse : Shape
    {
        private double bigaxis;
        private double smallaxis;

        public Ellipse()
        {
            Type = "Ellipse";
        }

        public override void SetData()
        {
            Console.Write("Enter the big axis: ");
            bigaxis = double.Parse(Console.ReadLine());
            Console.Write("Enter the small axis: ");
            smallaxis = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return PI * bigaxis * smallaxis;
        }

        public override double CalculateVolume()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{Type}: Big Axis = {bigaxis}, Small Axis = {smallaxis}, Area = {CalculateArea()}";
        }
    }

    // circle class and locgic
    public class Circle : Shape
    {
        private double radius;

        public Circle()
        {
            Type = "Circle";
        }

        public override void SetData()
        {
            Console.Write("Enter the radius: ");
            radius = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return PI * radius * radius;
        }

        public override double CalculateVolume()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{Type}: Radius = {radius}, Area = {CalculateArea()}";
        }
    }

    // cylinder class and locgic
    public class Cylinder : Shape
    {
        private double radius;
        private double height;

        public Cylinder()
        {
            Type = "Cylinder";
        }

        public override void SetData()
        {
            Console.Write("Enter the radius: ");
            radius = double.Parse(Console.ReadLine());
            Console.Write("Enter the height: ");
            height = double.Parse(Console.ReadLine());
        }


        public override double CalculateArea()
        {
            return 2 * PI * radius * radius + 2 * PI * radius * height;
        }

        public override double CalculateVolume()
        {
            return PI * radius * radius * height;
        }

        public override string ToString()
        {
            return $"{Type}: Radius = {radius}, Height = {height}, Area = {CalculateArea()}, Volume = {CalculateVolume()}";
        }
    }

    // sphere class and locgic
    public class Sphere : Shape
    {
        private double radius;

        public Sphere()
        {
            Type = "Sphere";
        }

        public override void SetData()
        {
            Console.Write("Enter the radius: ");
            radius = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return 4 * PI * radius * radius;
        }

        public override double CalculateVolume()
        {
            return 4 / 3 * PI * radius * radius * radius;
        }

        public override string ToString()
        {
            return $"{Type}: Radius = {radius}, Area = {CalculateArea()}, Volume = {CalculateVolume()}";
        }
    }

    // triangle class and locgic
    public class Triangle : Shape
    {
        private double bace;
        private double height;

        public Triangle()
        {
            Type = "Triangle";
        }

        public override void SetData()
        {
            Console.Write("Enter the base: ");
            bace = double.Parse(Console.ReadLine());
            Console.Write("Enter the height: ");
            height = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return (bace * height) / 2;
        }

        public override double CalculateVolume()
        {
            return 0;
        }


        public override string ToString()
        {
            return $"{Type}: Base = {bace}, Height = {height}, Area = {CalculateArea()}";
        }
    }

    // tetrahedron class and locgic
    public class Tetrahedron : Shape
    {
        private double edge;

        public Tetrahedron()
        {
            Type = "Tetrahedron";
        }

        public override void SetData()
        {
            Console.Write("Enter the edge: ");
            edge = double.Parse(Console.ReadLine());
        }

        public override double CalculateArea()
        {
            return Math.Sqrt(3) * edge * edge;
        }

        public override double CalculateVolume()
        {
            return (Math.Pow(edge, 3) / (6 * Math.Sqrt(2)));
        }

        public override string ToString()
        {
            return $"{Type}: Edge = {edge}, Area = {CalculateArea()}, Volume = {CalculateVolume()}";
        }
    }
}