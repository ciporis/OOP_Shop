﻿using System;

namespace Shop_5_5
{
    internal class CustomersGenerator
    {
        private int _maxBalance = 40000;

        private int _minProductsCount = 1;
        private int _maxProductsCount = 15;

        private Random _random = new Random();
        private int _customersCount;
        private Product[] _products;

        public CustomersGenerator(int customersCount, Product[] products)
        {
            _customersCount = customersCount;
            _products = products;
        }

        public int Total { get; private set; }

        public Customer[] GetRandomCustomers()
        {
            Customer[] customers = new Customer[_customersCount];

            for (int i = 0; i < _customersCount; i++)              
                customers[i] = GetRandomCustomer();

            return customers;
        }
        
        public Customer GetRandomCustomer()
        {
            int minProductIndex = 0;
            int maxProductIndex = _products.Length - 1;

            int randomProductsCount = _random.Next(_minProductsCount, _maxProductsCount + 1);

            Product[] randomProducts = new Product[randomProductsCount];

            for (int j = 0; j < randomProductsCount; j++)
            {
                int randomProductIndex = _random.Next(minProductIndex, maxProductIndex + 1);
                randomProducts[j] = _products[randomProductIndex];
                Total += randomProducts[j].Price;
            }

            int randomBalance = _random.Next(Total, _maxBalance + 1);

            return new Customer(randomBalance, randomProducts);
        }
    }
}
