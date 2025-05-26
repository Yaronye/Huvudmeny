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
            int number = 0;
            while (!exit)
            {
                Console.WriteLine("Welcome to the main menu.\nOptions:\n1.See ticket costs\n2.See group price\n3.Write a message\n4.Exit\n");
                input = Console.ReadLine()!;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter your age to see pricings\n");
                        number = StrToInt(Console.ReadLine()!);
                        ReturnPrice(number);
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!\n");
                        exit = true;
                        break;
                    case "2":
                        GroupPrice();
                        break;
                    case "3":
                        Console.WriteLine("Enter your message;\n");
                        input = Console.ReadLine()!;
                        Console.WriteLine("How many times would you like to display it?\n");
                        number = StrToInt(Console.ReadLine()!);
                        MessageLoop(input, number);
                        break;
                    default:
                        Console.WriteLine("That's not a valid input silly!\n");
                        break;
                }
            }
        }
        static int StrToInt(string strNumber)
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
        static int ReturnPrice(int age)
        {
            if (age < 0)
            {
                Console.WriteLine("\nPlease enter a valid age\n");
                return 0;
            }
            else if (age < 20)
            {
                Console.WriteLine("\nYouth ticket 80kr\n");
                return 80;
            }
            else if (age > 64)
            {
                Console.WriteLine("\nSenior price 90kr\n");
                return 90;
            }
            else if (age < 64)
            {
                Console.WriteLine("\nStandard ticket 120kr\n");
                return 120;
            }
            else
            {
                Console.WriteLine("\nUndefined\n");
                return 0;
            }
        }

        static int GroupPrice()
        {
            bool exit = false;
            int age;
            int totalPrice = 0;
            string choice = "n";
            do
            {
                Console.WriteLine("\nAdd another attendant? Y/N\n");
                choice = Console.ReadLine()!;
                
                if (choice == "n" || choice == "N")
                {
                    Console.WriteLine("\nThe final pricing for your group is {0} kr\n", totalPrice);
                    return totalPrice;
                }
                else if (choice == "y" || choice == "Y")
                {
                    Console.WriteLine("\nPlease enter the age of the next attendant\n");
                    age = StrToInt(Console.ReadLine()!);
                    totalPrice += ReturnPrice(age);
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

        static void MessageLoop(string message, int number)
        {
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("\n");
        }
    }
}