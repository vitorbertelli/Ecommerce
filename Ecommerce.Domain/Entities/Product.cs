using System.Data;

namespace Ecommerce.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Image> Images { get; set; }

    public Product(string name, decimal price, int stock)
    {
        SetName(name);
        SetPrice(price);
        SetStock(stock);
    }

    public Product(int id, string name, decimal price, int stock)
    {
        if (id < 0)
        {
            throw new Exception("Invalid id. Id is required.");
        }
        Id = id;
        SetName(name);
        SetPrice(price);
        SetStock(stock);
    }

    public void Update(string name, decimal price, int stock)
    {
        SetName(name);
        SetPrice(price);
        SetStock(stock);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Invalid name. Name is required.");
        }

        if (name.Length > 50)
        {
            throw new Exception("Name length cannot exceed 50 characters.");
        }

        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new Exception("Price cannot be negative or null.");
        }
        Price = price;
    }

    public void SetStock(int stock)
    {
        if (stock < 0)
        {
            throw new Exception("Stock cannot be negative or null.");
        }
        Stock = stock;
    }
}
