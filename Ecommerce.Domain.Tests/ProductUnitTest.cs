using Ecommerce.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Create Product With Valid Parameters")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", 9.99m, 99);
        action.Should().NotThrow<Exception>();
    }

    [Fact(DisplayName = "Create Product With Negative Id Value")]
    public void CreateProduct_NegativeIdValue_ExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", 9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Invalid id. Id is required.");
    }

    [Fact(DisplayName = "Create Product With Null Name Value")]
    public void CreateProduct_WithNullNameValue_ExceptionInvalidName()
    {
        Action action = () => new Product(1, null, 9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Product With Empty Name Value")]
    public void CreateProduct_WithEmptyNameValue_ExceptionInvalidName()
    {
        Action action = () => new Product(1, "", 9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Product With White Space Name Value")]
    public void CreateProduct_WithWhiteSpaceNameValue_ExceptionInvalidName()
    {
        Action action = () => new Product(1, " ", 9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Product With Name Larger Than 50 Characters")]
    public void CreateProduct_WithNameLargerThan50Characters_ExceptionInvalidName()
    {
        Action action = () => new Product(1, new string('1', 51), 9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Name length cannot exceed 50 characters.");
    }

    [Fact(DisplayName = "Create Product With With 50 Character Name Value")]
    public void CreateProduct_With50CharacterNameValue_ResultObjectValidState()
    {
        Action action = () => new Product(1, new string('1', 50), 9.99m, 99);
        action.Should().NotThrow<Exception>();
    }

    [Fact(DisplayName = "Create Prudoct With Negative Price Value")]
    public void CreateProduct_WithNegativePriceValue_ExceptionInvalidPrice()
    {
        Action action = () => new Product(1, "Product Name", -9.99m, 99);
        action.Should().Throw<Exception>().WithMessage("Price cannot be negative or null.");
    }

    [Fact(DisplayName = "Create Prudoct With Negative Stock Value")]
    public void CreateProduct_WithNegativeStockValue_ExceptionInvalidStock()
    {
        Action action = () => new Product(1, "Product Name", 9.99m, -99);
        action.Should().Throw<Exception>().WithMessage("Stock cannot be negative or null.");
    }
}