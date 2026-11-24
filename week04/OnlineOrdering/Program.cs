using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Denver", "Colorado", "USA");
        Customer customer1 = new Customer("Jordan Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Coffee Mug", "MUG100", 8.50m, 2));
        order1.AddProduct(new Product("Notebook", "NOTE200", 4.25m, 3));
        order1.AddProduct(new Product("Pen Set", "PEN300", 6.00m, 1));

        Address address2 = new Address("45 King Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Taylor Chen", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "BAG400", 32.00m, 1));
        order2.AddProduct(new Product("Water Bottle", "BOTTLE500", 12.50m, 2));

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine("Order " + orderNumber);
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("Total cost: $" + order.GetTotalCost().ToString("F2"));
            Console.WriteLine();
            orderNumber++;
        }
    }
}