using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Fitness App!;)");

            Console.WriteLine("Input User name please");
            var name = Console.ReadLine();

            #region additional info
            //Console.WriteLine("Select gender");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Input date of birth");
            //var birthdate = DateTime.Parse(Console.ReadLine()); // TODO: rewrite

            //Console.WriteLine("Input weight");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Input height");
            //var height = double.Parse(Console.ReadLine());
            #endregion

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Input gender: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime(); ;
                double weight = ParseDouble("Weight:");
                double height = ParseDouble("Height");

                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
           
            
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you wand to do?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Input name of product: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Calorific value");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");

            var weight = ParseDouble("Weight or portion");
            var product = new Food(food, calories, proteins, fats, carbs);

            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Input date of birth (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong format of date");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
           
            while (true)
            {
                Console.WriteLine($"Input {name}: ");
                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                    else
                {
                    Console.WriteLine($"Incorrect format of field: {name}");
                }
            }
        }
    }
}
