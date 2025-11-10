using System.Collections;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace GalacticPizzaChallenge;

class Program
{

    private static List<DeliveryLocation> _locations;
    private static List<MenuItem> _menu;

    private static Order _order;


    static void Main(string[] args)
    {
        _order = new Order();

        InitLocations();
        InitMenu();

        PrintBanner();

        PromptUserName();

        PromptDeliveryLocation();

        PromptOrder();

        PrintReceipt();
    }

    private static void InitLocations()
    {
        _locations = new List<DeliveryLocation>([
            new DeliveryLocation("location_1", "Earth", 5),
            new DeliveryLocation("location_2", "Mars", 10),
            new DeliveryLocation("location_3", "Jupiter Station", 15),
            new DeliveryLocation("location_4", "Venus Outpost", 8)
        ]);
    }
    
    private static void InitMenu()
    {
        _menu = new List<MenuItem>([
            new MenuItem("menuItem_1", "Galactic Cheese", 10),
            new MenuItem("menuItem_2", "Meteor Meat Lover", 15),
            new MenuItem("menuItem_3", "Veggie Nebula", 12),
            new MenuItem("menuItem_4", "Black Hole BBQ", 18)
        ]);
    }

    private static void PrintBanner()
    {
        Console.WriteLine("Welcome to Galactic Pizza!\n");
    }

    private static void PromptUserName()
    {
        Console.WriteLine("What is the name for your order?");
        Console.Write("Name: ");

        string name = Console.ReadLine() ?? "Anonymous User";
        _order.UserName = name;
    }

    private static void PromptDeliveryLocation()
    {
        int userSelection = -1;

        while (userSelection == -1)
        {
            Console.WriteLine("\n What planet should we deliver to?");

            for (int x = 0; x < _locations.Count; x++)
            {
                Console.WriteLine($"({x + 1}) {_locations[x].Name}");
            }
            Console.Write("Location: ");

            string? tempInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tempInput))
            {
                Console.WriteLine("Invalid Input!");
            }
            else if (int.TryParse(tempInput, out userSelection))
            {
                if (userSelection < 1 || userSelection > _locations.Count)
                {
                    Console.WriteLine("That is an invalid selection!");
                }
                else
                {
                    _order.Location = _locations[userSelection - 1];
                }
            }
            else
            {
                Console.WriteLine("Try using the numbers!");
            }
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\nChoose from the following (type \"done\" when you're finished):");

        for (int x = 0; x < _menu.Count; x++)
        {
            Console.WriteLine($"({x + 1}) {_menu[x].Name} ..... {_menu[x].Name}");
        }
    }

    private static void PromptOrder()
    {
        bool done = false;

        while (!done)
        {
            PrintMenu();

            string? tempInput = Console.ReadLine();
            int selection;

            if (string.IsNullOrWhiteSpace(tempInput))
            {
                Console.WriteLine("Invalid Input!");
            }
            else if (int.TryParse(tempInput, out selection))
            {
                if (selection < 1 || selection > _menu.Count)
                {
                    Console.WriteLine("That is an invalid selection!");
                }
                else
                {
                    _order.AddItem(_menu[selection - 1]);
                    Console.WriteLine($"Added a {_menu[selection - 1].Name} to your order.");
                }
            }
            else
            {
                if (tempInput.ToLower() == "done")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Try using the numbers or typing \"done\" if finished");
                }
            }
        }
    }

    private static void PrintReceipt()
    {
        if (_order.OrderItems.Count == 0)
        {
            Console.WriteLine("\nYou didn't order anything. See you again Next time!");
        }
        else
        {
            Console.WriteLine($"\nOrder for {_order.UserName} to {_order.Location.Name}");
            Console.WriteLine("-----------------------------------");

            float subtotal = 0;

            string[] orderItemKeys = _order.OrderItems.Keys.ToArray();

            for (int x = 0; x < orderItemKeys.Length; x++)
            {

                OrderItem orderItem = _order.OrderItems[orderItemKeys[x]];

                Console.WriteLine($"{orderItem.Quantity} x {orderItem.MenuItemName} @ {orderItem.MenuItemPrice}");
                subtotal += orderItem.TotalPrice;
            }

            Console.WriteLine($"Subtotal: {subtotal}");

            float total = subtotal + _order.Location.Fee;

            Console.WriteLine($"Delivery Fee: {_order.Location.Fee}");
            Console.WriteLine($"Total Due: {total} Credits");
        }
    }

}
