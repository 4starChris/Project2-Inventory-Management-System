/* Task:
 * Build a simple inventory management system for a small business. The system should allow the business to keep track of their product inventory, sales, and revenue. 
 * Here are some features that the system could include:
 *  Product Management: The system should allow the business to add, update, and delete products from their inventory. Each product should have a name, description, price, and quantity on hand.
 *  Sales Management: The system should allow the business to record sales transactions, including the products sold, the quantity sold, and the date and time of the sale. 
 *      The system should also update the inventory levels and calculate the revenue from each sale.
 *  Reports: The system should allow the business to generate reports on their sales and inventory data. For example, the business might want to see a list of their top-selling products, their revenue over a specific time period, or their current inventory levels.
 *  Security: The system should have user authentication and authorization features to prevent unauthorized access to sensitive data.

This project can help you learn how to work with data structures, such as arrays or lists, and how to use database management systems, such as SQL or Entity Framework, to store and retrieve data. 
It can also help you learn about user interfaces and input validation. You could add more features or complexity to the system, such as barcode scanning, order management, or integration with other software tools.
*/


// %7mcQmzE%jDi

/* Code Review information ------------------------
 * Right now, this program allows users to sell items. 
 * Available Keywords:
 *      "Sell" to sell fruits
 *      "CreateProduct" to create a new product in the system
 *      "Inventory" to view all of the products in stock
 *      "Transactions" to view a sales history
 *      "Quit" to close the application
 *      
 * Other features are currently not implemented yet.
 * */

using Project2_Inventory_Management_System;
using System;

class Program
{
    
    static void Main(string[] args)
    {
        Manager manager = Manager.Instance;
        
        //Create some starting products
        manager.createProduct("banana", "fruit", 3.50f, 50);
        manager.createProduct("mango", "fruit", 5.99f, 20);
        manager.createProduct("apple", "fruit", 2f);
        foreach (string name in manager.getProductList()){
            System.Console.WriteLine(name);
        }

        bool endapp = false;
        while (!endapp)
        {
            Console.WriteLine(Environment.NewLine+ "What action would you like to take?");
            string action = Console.ReadLine();
            switch (action.ToLower())
            {
                case "sell":
                    bool productFound = false;
                    string item = null;
                    while (!productFound)
                    {
                        Console.WriteLine("What item would you like to sell?");
                        item = Console.ReadLine();
                        if (!manager.ProductExists(item)) { Console.WriteLine("Product not registered."); continue; };

                        productFound = true;
                    }
                                                          
                    int quantity = -1; 
                    string quantityString;
                    while (quantity < 0)
                    {
                        Console.WriteLine("How many " + item + " would you like to sell?");
                        quantityString = Console.ReadLine();
                        try { quantity = Convert.ToInt32(quantityString); break;} catch { Console.WriteLine("Not a number"); continue; }
                    }
                    if (manager.Sell(item, quantity) == 1) { Console.WriteLine("Item successfully Sold"); }
                    else { Console.WriteLine("Item sale failed"); }
                    break;

                case "createproduct":
                    Console.WriteLine("What is the name of the new product?");
                    string name = Console.ReadLine();

                    Console.WriteLine("Provide a brief description of the product.");
                    string desc = Console.ReadLine();

                    float price = -1f;
                    string priceString;
                    while (price < 0)
                    {
                        Console.WriteLine("What is the cost of the product?");
                        priceString = Console.ReadLine();
                        try { price = Convert.ToInt32(priceString);} catch { Console.WriteLine("Not a number"); continue; }
                        if (price < 0) { Console.WriteLine("Price can't be a negative number."); continue; }
                    }

                    int initialquantity = -1;
                    string initialquantityString;
                    while (initialquantity < 0)
                    {
                        Console.WriteLine("How many " + name + " are initially in stock?");
                        initialquantityString = Console.ReadLine();
                        try { initialquantity = Convert.ToInt32(initialquantityString); } catch { Console.WriteLine("Not a number"); continue; }
                        if (initialquantity < 0) { Console.WriteLine("Quantity can't be a negative number."); continue; }
                    }

                    manager.createProduct(name, desc, price, initialquantity);
                    break;

                case "inventory":
                    manager.ViewInventory();
                    break ;

                case "transactions":
                    manager.ViewTransactions();
                    break;

                case "quit":
                    endapp = true;
                    break;

                default:
                    Console.WriteLine("Invalid action.");
                    continue;



            }
        }

        Console.WriteLine("App ending");
    }




    
    
}