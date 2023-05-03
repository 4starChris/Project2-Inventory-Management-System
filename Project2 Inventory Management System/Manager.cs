using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Inventory_Management_System
{
    public class Manager
    {
        private static Manager _instance;

        public List<Product> productsList = new List<Product>();
        public List<Transaction> transactionsList = new List<Transaction>();

        private Manager()
        {

        }
        
        public static Manager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Manager();

                return _instance;
            }
        }

        public void AddNewProduct(Product product)
        {
            productsList.Add(product);
            return;
        }

        public void AddNewTransaction(Transaction transaction)
        {
            transactionsList.Add(transaction);
            return;
        }

        public int numberOfTransactions()
        {
            return transactionsList.Count;
        }

        //Try to sell product if given a Product
        public int Sell(Product product, int quantity)
        {
            if (!productsList.Contains(product)) { return 0; }
            if (!product.RemoveItem(quantity)) { System.Console.WriteLine("Not enough items in stock to sell!"); return 0; }

            new Transaction(product, quantity, DateTime.Today);
            return 1;
        }

        //Try to sell product if given a string name
        public int Sell(string productName, int quantity)
        {
            //Find product
            bool exists = false;
            Product productfound = null;
            foreach (Product product in productsList)
            {
                if (product.name == productName) { productfound = product;  exists = true; break; }

            }
            if (!exists) { return 0; }
            return this.Sell(productfound, quantity);
        }

        //Find if product exists
        public bool ProductExists(string productName)
        {
            //Check if product exists
            bool exists = false;
            Product productfound = null;
            foreach (Product product in productsList)
            {
                if (product.name == productName) { exists = true; break; }

            }
            return exists;
        }

        public List<string> getProductList()
        {
            List<string> list = new List<string>();
            foreach (Product product in productsList)
            {
                list.Add(product.name);
            }
            return list;
        }

        public void ViewInventory()
        {
            foreach (Product product in productsList)
            {
                Console.WriteLine("Name: " + product.name + "     Quantity: " + product.quantity);
            }
            return;
        }

        public void ViewTransactions()
        {
            foreach (Transaction transaction in transactionsList)
            {
                Console.WriteLine("Name: " + transaction.product.name + "     Quantity: " + transaction.quantitySold + "     Date: " + transaction.date);
            }
        }

        public void createProduct(string name, string desc, float price)
        {
            Product product = new Product(name, desc, price, 0);

        }


        public void createProduct(string name, string desc, float price, int quantity)
        {
            Product product = new Product(name, desc, price, quantity);
        }
    }
}
