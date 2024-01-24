using Ecommerce.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Tests;

public class ImageUnitTest
{
    [Fact(DisplayName = "Create Image With Valid Parameters")]
    public void CreateImage_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Image(1, "Image Url");
        action.Should().NotThrow<Exception>();
    }

    [Fact(DisplayName = "Create Image With Negative Id Value")]
    public void CreateImage_WithNegativeIdValue_ExceptionInvalidId()
    {
        Action action = () => new Image(-1, "Image Url");
        action.Should().Throw<Exception>().WithMessage("Invalid id. Id is required.");
    }

    [Fact(DisplayName = "Create Image With Null Url Value")]
    public void CreateImage_WithNullUrlValue_ExceptionInvalidUrl()
    {
        Action action = () => new Image(1, null);
        action.Should().Throw<Exception>().WithMessage("Invalid url. Url is required.");
    }

    [Fact(DisplayName = "Create Image With Empty Url Value")]
    public void CreateImage_WithEmptyUrlValue_ExceptionInvalidUrl()
    {
        Action action = () => new Image(1, "");
        action.Should().Throw<Exception>().WithMessage("Invalid url. Url is required.");
    }

    [Fact(DisplayName = "Create Image With White Space Url Value")]
    public void CreateImage_WithWhiteSpaceUrlValue_ExceptionInvalidUrl()
    {
        Action action = () => new Image(1, " ");
        action.Should().Throw<Exception>().WithMessage("Invalid url. Url is required.");
    }

    [Fact(DisplayName = "Create Image With Url Larger Than 250 Characters")]
    public void CreateImage_WithUrleLargerThan50Characters_ExceptionInvalidUrl()
    {
        Action action = () => new Image(1, new string('1', 251));
        action.Should().Throw<Exception>().WithMessage("Url length cannot exceed 250 characters.");
    }

    [Fact(DisplayName = "Create Image With With 50 Character Url Value")]
    public void CreateImage_With50CharacterUrlValue_ResultObjectValidState()
    {
        Action action = () => new Image(1, new string('1', 250));
        action.Should().NotThrow<Exception>();
    }
}