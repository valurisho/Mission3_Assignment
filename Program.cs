
using System;
using Mission3_Assignment;

//keep the program running until the user selects Exit

public class Program
{
    //probably need a array that is the inventory??
    static List<FoodItem> inventory = new List<FoodItem>(); //not sure what this means
    
    private static void Main(string[] args)
    {
        
        bool keepGoing = true;
        while (keepGoing)
        {
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (only the number): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddFoodItem();
            }
            else if (choice == "2")
            {
                DeleteFoodItem();
            }
            else if (choice == "3")
            {
                PrintInventory();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thanks for using the Food Bank Inventory System." +
                                  " Exiting the Program...");
                keepGoing = false;
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
            }
        }
    }
    private static void AddFoodItem()
    {
        Console.WriteLine("Enter Food Item Name: ");
        string foodName = Console.ReadLine();

        Console.WriteLine("Enter Food Item Category: ");
        string foodCategory = Console.ReadLine();

        int foodQuantity = 0;
        bool quantityValid = true;
        while (quantityValid)
        {
            Console.WriteLine("Enter Food Item Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out foodQuantity) || foodQuantity <= 0) //If it can't parse it to an integer or it is negative
            {
                Console.WriteLine("Please enter a valid quantity.");
                return;
            }
            else
            {
                quantityValid = false;
            }
        }
        
        DateTime expirationDate = DateTime.MinValue;
        bool dateRight = true;
        while(dateRight)
        {
            Console.WriteLine("Enter Expiration Date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out expirationDate) || expirationDate < DateTime.Now)
            {
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
            }
            else
            {
                dateRight = false;
            }
        }
        
        FoodItem item = new FoodItem(foodName,foodCategory,foodQuantity,expirationDate); 
        inventory.Add(item);
        Console.WriteLine("Item added successfully");

    }

    static private void DeleteFoodItem()
    {
        PrintInventory();
        Console.WriteLine("Enter name of item to delete: ");
        string foodName = Console.ReadLine();
        
        //lambda expression
        FoodItem itemToDelete = inventory.FirstOrDefault(item => item.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase));
        
        //if it find an item with that name then it adds it to the variable itemtoDelelet, if not, it returns null
        if (itemToDelete != null) //if it is not null then it deletes
        {
            inventory.Remove(itemToDelete);
            Console.WriteLine(itemToDelete.Name + " was deleted");
        }
        else
        {
            Console.WriteLine($" {foodName} not found in the inventory.");
        }

    }

    static void PrintInventory()
    {
        if (inventory.Count == 0) //it doesn't have the lenght property, it has a count property
        {
            Console.WriteLine("There are no items in the inventory.");
            return;
        }
        else
        {
            Console.WriteLine("\nThese are the items in the inventory:");
            Console.WriteLine("  Name  | Category  | Quantity | Expiration Date");
            for (int i = 0; i < inventory.Count; i++) 
            {
                FoodItem foodItem = inventory[i];
                Console.WriteLine($"{foodItem.Name} | {foodItem.Category} |   {foodItem.Quantity}  | {foodItem.ExpirationDate:yyyy-MM-dd}");
            }
        }
        
    }
}

