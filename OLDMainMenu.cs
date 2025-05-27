using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "";
            bool exit = false;
            int age = 0;
            while (!exit)
            {
                Console.WriteLine("Welcome to the main menu.\nOptions:\n1.See ticket costs\n2.See group price\n3.Exit\n");
                input = Console.ReadLine()!;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter your age to see pricings\n");
                        age = strToInt(Console.ReadLine()!);
                        Console.WriteLine(printPricing(returnPrice(age)));
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!\n");
                        exit = true;
                        break;
                    case "2":
                        groupPrice();
                        break;
                    default:
                        Console.WriteLine("That's not an input silly!\n");
                        break;
                }
            }
        }
        static int strToInt(string strNumber)
        {
            int intNumber;
            try
            {
                intNumber = Int32.Parse(strNumber);
                return intNumber;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strNumber}' to int + \n");
            }
            return -1;
        }
        static string printPricing(int price)
        {
            switch (price)
            {
                case -1:
                    return "\n Please enter a real age";
                case 80:  //ungdom
                    return "\nYouth ticket 80kr\n";
                case 90:  //pensionär
                    return "\nSenior price 90kr\n";
                case 120:
                    return "\nStandard ticket 120kr\n";
                default:
                    return "\nPlease enter a real age\n";
            }
        }
        static int returnPrice(int age)
        {
            switch (age)
            {
                case < 0:
                    return 0;
                case < 20:  //ungdom
                    return 80;
                case > 64:  //pensionär
                    return 90;
                case < 64:
                    return 120;
                default:
                    return 0;
            }
        }

        static int groupPrice()
        {
            bool exit = false;
            int age;
            int totalPrice = 0;
            string choice = "n";
            do
            {
                Console.WriteLine("\nPlease enter the age of your next attendant\n");
                age = strToInt(Console.ReadLine()!);
                int tempPrice = returnPrice(age);
                printPricing(tempPrice);
                totalPrice += tempPrice;
                Console.WriteLine("\nAdd another attendant? Y/N\n");
                choice = Console.ReadLine()!;
                if (choice == "n" || choice == "N")
                {
                    Console.WriteLine("\nThe final pricing for your group is {0} kr\n", totalPrice);
                    return totalPrice;
                }
                else if (choice == "y" || choice == "Y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\nPlease answer using 'Y' or 'N'.\n");
                    continue;
                }
            }
            while (!exit);
            return totalPrice;
        }
	}
}
