using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GalacticPizzaChallenge;

class Program
{

    private static string[] planets = { "Earth", "Mars", "Jupiter", "Saturn", "Venus", "Outpost" };

    static void Main(string[] args)
    {
        string userName = "";
        string deliveryLocation = "";
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

    private static string promptDeliveryLocation()
    {
        int userSelection = -1;

        while(userSelection == -1)
        {
            Console.WriteLine("\n What planet should we deliver to?");

            for (int x = 0; x < planets.Length; x++)
            {
                Console.WriteLine($"({x + 1}) {planets[x]}");
            }
            Console.Write("Location: ");

            string? tempInput = Console.ReadLine();

            if (tempInput == null)
            {
                Console.WriteLine("Invalid Input!");
            }
            else if (int.TryParse(tempInput, out userSelection)) {
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

        return planets[userSelection - 1];
    }


}
