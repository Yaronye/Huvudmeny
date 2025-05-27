using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Program
    {
        /*
            Main method, Presents the user with 5 choices;
        1. See ticket costs
        2. See group price
        3. Repeat a message
        4. The third word
        5. Exit the program

        We create a while loop that continues while exit is not true (while the user has not requested the exit option) and create a switch case within it.
        */
        static void Main(string[] args)
        {
            String strInput = "";
            bool exit = false;
            int intInput = 0;
            while (!exit)
            {
                Console.WriteLine("Welcome to the main menu.\nOptions:\n1.See ticket costs\n2.See group price\n3.Repeat a message\n4.The third word\n5.Exit\n");
                strInput = Console.ReadLine()!;
                switch (strInput)
                {
                    case "1":
                        Console.WriteLine("Enter your age to see pricings\n");
                        intInput = StrToInt(Console.ReadLine()!);
                        ReturnPrice(intInput);
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!\n");
                        exit = true;
                        break;

                    case "2":
                        GroupPrice();
                        break;

                    case "3":
                        Console.WriteLine("Enter your message;\n");
                        strInput = Console.ReadLine()!;
                        Console.WriteLine("How many times would you like us to repeat it?\n");
                        intInput = StrToInt(Console.ReadLine()!);
                        MessageLoop(strInput, intInput);
                        break;

                    case "4":
                        Console.WriteLine("Enter your message with three or more words in it:\n");
                        strInput = Console.ReadLine()!;
                        string[] list = CreateSplitList(strInput);
                        if (ThreeOrMoreCheck(list))
                        {
                            strInput = ReturnThirdElement(list);
                            Console.WriteLine("The third word in your sentence is '{0}'!\n", strInput);
                        }
                        else
                        {
                            Console.WriteLine("Please enter at least three words.\n");
                        }
                            break;

                    default:
                        Console.WriteLine("That's not a valid input silly!\n");
                        break;
                }
            }
        }

        static int StrToInt(string strNumber)   //Takes a string as input and tries to return it as an int.
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
        static int ReturnPrice(int age) //Returns ticket prices based on input age
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

        static int GroupPrice()     //The user is able to keep adding attendants ages to see final cost of the summarized tickets
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

        static void MessageLoop(string message, int number)         //Writes to console the inputed string an inputed int number of times
        {
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("\n");
        }

        static string[] CreateSplitList(string strInput)            //Splits a string based on blanks and returns them in a string list
        {
            var elements = strInput.Split(' ');
            return elements;
        }

        static string ReturnThirdElement(string[] list)             //A string list is inputed and the third element is returned
        {
            return list[2];
        }

        static bool ThreeOrMoreCheck(string[] list)              //Return true if the inputed string list has 3 or more elements, false if it does not
        {
            if (list.Length < 3)
            {
                return false;
            }
            else { return true; }
        }
    }
}