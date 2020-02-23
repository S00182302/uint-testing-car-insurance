using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing_app.Models;

namespace testing_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            DisplayMenu(driver);



        }

        public static void AddDriverForm(Driver driver)
        {
            Console.WriteLine("Please enter your details");
            Console.Write("Please enter your date of birth(dd/mm/yyyy): ");
            driver.DOB = DateTime.Parse(Console.ReadLine());
            Console.Write("Please enter the value of the car: ");
            driver.VehicleValue = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please select \n[1] for comprehensive \n[2] for third party");
            int tempValue = int.Parse(Console.ReadLine());
            driver.InsuranceType = (tempValue == 2) ? InsuranceType.ThirdParty : InsuranceType.Comprehensive;
            Console.Write("Please enter your penalty points: ");
            driver.PenaltyPoints = int.Parse(Console.ReadLine());
        }


        public static void DisplayMenu(Driver driver)
        {
            int response;
            do
            {
                Console.WriteLine("1.Insert details and calculate quote");
                Console.WriteLine("2. Quit");
                Console.WriteLine("Enter Choice:");
                response = int.Parse(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        AddDriverForm(driver);
                        PrintQuote(driver);
                        break;
                    default:
                        break;
                }
            }

            while (response != 2);
        }

        public static void PrintQuote(Driver driver)
        {
            decimal quote = driver.CalculateQuote(DateTime.Now);
            if (quote != -1)
            {
                Console.WriteLine(string.Format("Your insurance quote is: {0:0.00}", quote));
            }
            else
            {
                Console.WriteLine("No Quote POSSIBLE");
            }
            
        }
    }
}
