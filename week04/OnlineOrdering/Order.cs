using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0m;

        foreach (Product product in _products)
        {
            totalCost = totalCost + product.GetTotalCost();
        }

        decimal shippingCost = 35m;

        if (_customer.IsInUSA())
        {
            shippingCost = 5m;
        }

        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in _products)
        {
            label = label + product.GetName() + " - Product ID: " + product.GetProductId() + "\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetName() + "\n" + _customer.GetAddress().GetFullAddress();
    }
}
