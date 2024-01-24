namespace Ecommerce.Domain.Entities;

public class Image
{
    public int Id { get; private set; }
    public string Url { get; private set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public Image(string url)
    {
        SetUrl(url);
    }

    public Image(int id, string url)
    {
        if (id < 0)
        {
            throw new Exception("Invalid id. Id is required.");
        }
        Id = id;
        SetUrl(url);
    }

    public void Update(string url)
    {
        SetUrl(url);
    }

    public void SetUrl(string url)
    {
        if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
        {
            throw new Exception("Invalid url. Url is required.");
        }

        if (url.Length > 250)
        {
            throw new Exception("Url length cannot exceed 250 characters.");
        }

        Url = url;
    }
}
