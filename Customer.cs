using System;
using System.Collections.Generic;

namespace Shop_5_5
{
    internal class Customer
    {
        private Product[] _products;

        public Customer(int balance, Product[] producsts)
        {
            Balance = balance;
            _products = producsts;
        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach (Product product in _products)
                total += product.Price;

            return total;
        }

        public void ShowCart()
        {
            foreach (Product product in _products)
                Console.WriteLine($"{product.Name}: {product.Price}$");

            Console.WriteLine();
            Console.WriteLine($"Total: {GetTotalPrice()}$");
        }

        public int Balance { get; private set; }
        public IReadOnlyList<Product> Products => Array.AsReadOnly(_products);
    }
}