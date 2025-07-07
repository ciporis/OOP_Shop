namespace Shop_5_5
{
    internal class Customer
    {
        public int Balance { get; private set; }
        public Product[] Products { get; private set; }//private
        public int ProductsCount => Products.Length;
        public int Total { get; private set; }

        public Customer(int balance, Product[] producsts)
        {
            Balance = balance;

            foreach (Product product in producsts)
            {
                Total += product.Price;
            }

            Products = producsts;//создать метод get total вместо этого
        }
    }
}