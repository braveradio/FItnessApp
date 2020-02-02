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
            Console.ReadLine();
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
                    Console.WriteLine($"Incorrect format of name: {name}");
                }
            }
        }
    }
}
