using System;

namespace Shop_5_5
{
    internal class Seller
    {
        private Shop _shop;

        public Seller(Shop shop)
        {
            _shop = shop;
        }

        public void SellProducts(Customer customer)
        {
            Console.Clear();

            int balance = customer.Balance;
            
            for (int i = 0; i < customer.Products.Count; i++)
            {
                Product product = customer.Products[i];

                if (balance - product.Price >= 0)
                {
                    Console.WriteLine($"{product.Name} was successfully sold");
                    balance -= product.Price;
                    _shop.AddMoney(product.Price);
                }
                else
                {
                    Console.WriteLine($"{product.Name} is too expensive");

                    if (i == customer.Products.Count - 1)
                    {
                        _shop.Queue.Dequeue();
                        return;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            _shop.Queue.Dequeue();
        }
    }
}