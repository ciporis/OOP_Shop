using System;

namespace Shop_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowBalanceAction = "Show balance";
            const string ShowNextCustomerAction = "Show next customer in line";
            const string ExitAction = "Exit";

            const string SellProductsToCustomerAction = "Sell products to this customer";
            const string RejectSellingProductsToCustomerAction = "Reject selling to this customer";

            Product[] products = 
            {
                new Product("Laptop", 650),
                new Product("Smartphone", 399),
                new Product("Headphones", 99),
                new Product("Keyboard", 49),
                new Product("Mouse", 25),
                new Product("Monitor", 199),
                new Product("Tablet", 299),
                new Product("Printer", 129),
                new Product("Speaker", 79),
                new Product("Camera", 450),
                new Product("SSD Drive", 89),
                new Product("Router", 75),
                new Product("Smartwatch", 199),
                new Product("External HDD", 59),
                new Product("USB Flash Drive", 15)
            };

            Shop shop = new Shop(products);
            Seller seller = new Seller(shop);

            Console.WriteLine("Enter customers count:");
            int cusomersCount = int.Parse(Console.ReadLine());

            Console.Clear();

            var customersGenerator = new CustomersGenerator(cusomersCount, products);
            Customer[] customers = customersGenerator.GetRandomCustomers();

            shop.AddQueue(customers);

            string[] mainMenuActions =
            {
                ShowBalanceAction,
                ShowNextCustomerAction,
                ExitAction,
            };

            string[] clientMenuActions =
            {
                SellProductsToCustomerAction,
                RejectSellingProductsToCustomerAction,
            };

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Choose an action number");

                for (int i = 0; i < mainMenuActions.Length; i++)
                    Console.WriteLine($"{i + 1}) {mainMenuActions[i]}");

                int actionIndex = int.Parse(Console.ReadLine()) - 1;

                switch (mainMenuActions[actionIndex])
                {
                    case ShowBalanceAction:
                        Console.WriteLine(shop.Balance);
                        break;
                    case ShowNextCustomerAction:
                        if (shop.Queue.Count == 0)
                        {
                            Console.WriteLine("There are no customers!!!");
                            isWorking = false;
                            break;
                        }

                        Customer currentCustomer = shop.Queue.Peek();

                        Console.Clear();

                        currentCustomer.ShowCart();
                        Console.WriteLine($"Customer's balance: {currentCustomer.Balance}$");
                        Console.WriteLine();

                        for (int j = 0; j < clientMenuActions.Length; j++)
                            Console.WriteLine($"{j + 1}) {clientMenuActions[j]}");

                        int clientActionIndex = int.Parse(Console.ReadLine()) - 1;

                        switch (clientMenuActions[clientActionIndex])
                        {
                            case SellProductsToCustomerAction:
                                seller.SellProducts(currentCustomer);
                                break;
                            case RejectSellingProductsToCustomerAction:
                                break;
                        }

                        break;
                    case ExitAction:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}