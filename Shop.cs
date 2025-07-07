using System.Collections.Generic;

namespace Shop_5_5
{
    internal class Shop
    {
        public Product[] Products { get; private set; }
        public int Balance { get; private set; }
        public Queue<Customer> Queue = new Queue<Customer>();

        public Shop(Product[] products)
        {
            Products = products;
            Balance = 0;
        }

        public void AddQueue(Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                Queue.Enqueue(customer);
            }
        }

        public void Sell()
        {
            Customer currentCustomer = Queue.Peek();

            foreach(Product product in currentCustomer.Products)
            {
                Balance += product.Price;
            }

            Queue.Dequeue();
        }

        public void Reject()
        {
            Queue.Dequeue();
        }
    }
}
