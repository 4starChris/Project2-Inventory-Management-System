using System;

namespace Project2_Inventory_Management_System
{


    public class Product
    {
        public string name;
        public string description;
        public double price;
        public int quantity;
        Manager manager = Manager.Instance;

        public Product(string name, string description, float price, int quantity)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            manager.AddNewProduct(this);
        }

        public void AddItem(int amount)
        {
            quantity += amount;
            return;
        }

        public bool RemoveItem(int amount)
        {
            if (amount > quantity)
            {
                Console.WriteLine("You don't have enough! You only have " + quantity + " on hand.");
                return false;
            }

            quantity -= amount;
            return true;
        }
    }
}