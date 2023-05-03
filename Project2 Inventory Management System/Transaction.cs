using System;

namespace Project2_Inventory_Management_System
{
    public class Transaction
    {
        public Product product;
        public int quantitySold;
        public DateTime date;
        Manager manager = Manager.Instance;

        public Transaction(Product productName, int quantitySold, DateTime date)
        {
            this.product = productName;
            this.quantitySold = quantitySold;
            this.date = date;
            manager.AddNewTransaction(this);
        }

    }
}

