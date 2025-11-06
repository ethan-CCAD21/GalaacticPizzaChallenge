using System.Collections;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GalacticPizzaChallenge;

class Program
{

    private static (string, float)[] planets =
    {
        ("Earth", 5),
        ("Mars", 10),
        ("Jupiter Station", 15),
        ("Venus Outpost", 8)
    };

    private static (string, float)[] menu =
    {
        ("Galactic Cheese", 10),
        ("Meteor Meat Lover", 15),
        ("Veggie Nebula", 12),
        ("Black Hole BBQ", 18)
    };

    static void Main(string[] args)
    {
        string userName = "";
        int deliveryLocation = -1;

        printBanner();

        userName = promptUserName();

        deliveryLocation = promptDeliveryLocation();
    }

    private static void printBanner()
    {
        Console.WriteLine("Welcome to Galactic Pizza!\n");
    }

    private static string promptUserName()
    {
        Console.WriteLine("What is the name for your order?");
        Console.Write("Name: ");
        return Console.ReadLine() ?? "";
    }

    private static int promptDeliveryLocation()
    {
        int userSelection = -1;

        while (userSelection == -1)
        {
            Console.WriteLine("\n What planet should we deliver to?");

            for (int x = 0; x < planets.Length; x++)
            {
                Console.WriteLine($"({x + 1}) {planets[x].Item1}");
            }
            Console.Write("Location: ");

            string? tempInput = Console.ReadLine();

            if (tempInput == null)
            {
                Console.WriteLine("Invalid Input!");
            }
            else if (int.TryParse(tempInput, out userSelection))
            {
                if (userSelection < 0 || userSelection >= planets.Length)
                {
                    Console.WriteLine("That is an invalid selection!");
                }
            }
            else
            {
                Console.WriteLine("Try using the numbers!");
            }
        }

        return userSelection - 1;
    }

    private static void printMenu()
    {
        
    }
    
    private static ArrayList promptOrder()
    {
        ArrayList orders = new ArrayList();

        

        return orders;
    }


}
