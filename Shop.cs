using System.Collections.Generic;

namespace Shop_5_5
{
    internal class Shop
    {
        public Queue<Customer> Queue = new Queue<Customer>();

        public Shop(Product[] products)
        {
            Products = products;
            Balance = 0;
        }

        public Product[] Products { get; private set; }
        public int Balance { get; private set; }

        public void AddQueue(Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                Queue.Enqueue(customer);
            }
        }

        public void AddMoney(int amount)
        {
            Balance += amount;
        }
    }
}
