namespace Ecommerce.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        SetName(name);
    }

    public Category(int id, string name)
    {
        if (id < 0)
        {
            throw new Exception("Invalid id. Id is required.");
        }
        Id = id;
        SetName(name);
    }

    public void Update(string name)
    {
        SetName(name);
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
}
