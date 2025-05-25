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
			while (!exit)
			{
                Console.WriteLine("Welcome to the main menu\nOptions:\n0.Greeting\n1.Exit");
                input = Console.ReadLine()!;
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Hello!!");
                        break;
                    case "1":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("That's not an input silly!");
                        break;
                }
			}
		}
	}
}
