using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopping
{
    // Bug: When you remove a vehicle it removes all vehicles with same specification
    // Bug: When you do not enter a number for vehicle year, program breaks
    // Bug: When looking up or removing vehicle, when you specify how to look up the vehicle
    //      and enter a non-matching string, there is no notification, returns to menu

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> inventory = new List<Car>();

            Menu(ref inventory);
        }

        public static void Menu(ref List<Car> inventory)
        {
            Console.WriteLine();
            Console.WriteLine("A - Add vehicle      L - Lookup vehicle(s)");
            Console.WriteLine("R - Remove vehicle   V - View entire inventory");
            Console.WriteLine("E - Exit");
            Console.WriteLine();

            Console.Write("What would you like to do? ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "a")
            {
                Vehicles.addCars(ref inventory);
                Menu(ref inventory);
            }
            else if (userInput == "r")
            {
                Vehicles.removeCars(ref inventory);
                Menu(ref inventory);
            }
            else if (userInput == "l")
            {
                Vehicles.lookupCars(ref inventory);
                Menu(ref inventory);
            }
            else if (userInput == "e")
                Environment.Exit(0);
            else if (userInput == "v")
            {
                Vehicles.entireInventory(ref inventory);
                Menu(ref inventory);
            }
            else
            {
                Console.WriteLine("I did not understand that.");
                Menu(ref inventory);
            }
        }
    }

    class Vehicles
    {
        internal static void addCars(ref List<Car> inventory)
        {
            Console.WriteLine();
            Console.Write("What is the make? ");
            string make = Console.ReadLine();
            Console.Write("What is the model? ");
            string model = Console.ReadLine();
            Console.Write("What is the year? ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is the color? ");
            string color = Console.ReadLine();
            Car car = new Car(make, model, year, color);
            inventory.Add(car);
            Console.WriteLine();
            Console.WriteLine("{0} - {1} - {2} - {3} - Added", make, model, year, color);
        }

        internal static void removeCars(ref List<Car> inventory)
        {
            Console.WriteLine();
            Console.WriteLine("M - Make     O - Model");
            Console.WriteLine("Y - Year     C - Color     E - Go Back");
            Console.WriteLine();
            Console.Write("How would you like to look up the car? ");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "M")
            {
                Console.Write("What is the make? ");
                string make = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Make == make)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3} - Removed", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                        inventory.RemoveAll(a => vehicle.Make == make);
                        break;
                    }
                }
            }

            else if (userInput == "O")
            {
                Console.Write("What is the model? ");
                string model = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Model == model)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3} - Removed", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                        inventory.RemoveAll(a => vehicle.Model == model);
                        break;
                    }
                }
            }

            else if (userInput == "Y")
            {
                Console.Write("What is the year? ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Year == year)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3} - Removed", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                        inventory.RemoveAll(a => vehicle.Year == year);
                        break;
                    }
                }
            }

            else if (userInput == "C")
            {
                Console.Write("What is the color? ");
                string color = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Color == color)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3} - Removed", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                        inventory.RemoveAll(a => vehicle.Color == color);
                        break;
                    }
                }
            }

            else if (userInput == "E")
                Program.Menu(ref inventory);

            else
            {
                Console.WriteLine("I did not understand that.");
                Vehicles.lookupCars(ref inventory);
            }
        }

        internal static void lookupCars(ref List<Car> inventory)
        {
            Console.WriteLine();
            Console.WriteLine("M - Make     O - Model");
            Console.WriteLine("Y - Year     C - Color     E - Go Back");
            Console.WriteLine();
            Console.Write("How would you like to look up the car? ");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "M")
            {
                Console.Write("What is the make? ");
                string make = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Make == make)
                        Console.WriteLine("{0} - {1} - {2} - {3}", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                }
            }

            else if (userInput == "O")
            {
                Console.Write("What is the model? ");
                string model = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Model == model)
                        Console.WriteLine("{0} - {1} - {2} - {3}", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                }
            }

            else if (userInput == "Y")
            {
                Console.Write("What is the year? ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Year == year)
                        Console.WriteLine("{0} - {1} - {2} - {3}", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                }
            }

            else if (userInput == "C")
            {
                Console.Write("What is the color? ");
                string color = Console.ReadLine();
                Console.WriteLine();

                foreach (Car vehicle in inventory)
                {
                    if (vehicle.Color == color)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3}", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
                    }
                }
            }

            else if (userInput == "E")
                Program.Menu(ref inventory);

            else
            {
                Console.WriteLine("I did not understand that.");
                Vehicles.lookupCars(ref inventory);
            }
        }

        internal static void entireInventory(ref List<Car> inventory)
        {
            Console.WriteLine();
            foreach (Car vehicle in inventory)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Color);
            }
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }
    }
}
