using Ecommerce.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category With Valid Parameters")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should().NotThrow<Exception>();
    }

    [Fact(DisplayName = "Create Category With Negative Id Value")]
    public void CreateCategory_WithNegativeIdValue_ExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should().Throw<Exception>().WithMessage("Invalid id. Id is required.");
    }

    [Fact(DisplayName = "Create Category With Null Name Value")]
    public void CreateCategory_WithNullNameValue_ExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Category With Empty Name Value")]
    public void CreateCategory_WithEmptyNameValue_ExceptionInvalidName()
    {
        Action action = () => new Category(1, "");
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Category With White Space Name Value")]
    public void CreateCategory_WithWhiteSpaceNameValue_ExceptionInvalidName()
    {
        Action action = () => new Category(1, " ");
        action.Should().Throw<Exception>().WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Category With Name Larger Than 50 Characters")]
    public void CreateCategory_WithNameLargerThan50Characters_ExceptionInvalidName()
    {
        Action action = () => new Category(1, new string('1', 51));
        action.Should().Throw<Exception>().WithMessage("Name length cannot exceed 50 characters.");
    }

    [Fact(DisplayName = "Create Category With With 50 Character Name Value")]
    public void CreateCategory_With50CharacterNameValue_ResultObjectValidState()
    {
        Action action = () => new Category(1, new string('1', 50));
        action.Should().NotThrow<Exception>();
    }
}