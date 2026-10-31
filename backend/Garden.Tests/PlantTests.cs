using Garden.Application.Dtos;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace Garden.Tests;

public class PlantTests
{
    [Fact]
    public void CreatePlantDto_Validation_Fails_When_Name_Is_Empty()
    {
        // Arrange
        var dto = new CreatePlantDto { Name = "", Location = "Теплица" };
        var context = new ValidationContext(dto);
        var results = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(dto, context, results, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r => r.ErrorMessage.Contains("Название обязательно"));
    }
}