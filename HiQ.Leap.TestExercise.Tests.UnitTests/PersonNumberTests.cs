using HiQ.Leap.TestExercise.Services.Helpers;
using Xunit;

namespace HiQ.Leap.TestExercise.Tests.UnitTests;

public class PersonNumberTests
{
    [Fact]
    public void PersonNumberValidator_IsValidPersonNumber_Expect_Valid_True_Simple()
    {
        // All person numbers are generated from fejk.se
        var result = PersonNumberValidator.IsValidPersonNumber("7210047168");
        Assert.True(result);
    }

    [Theory]
    [InlineData("7210047168")]
    [InlineData("6406090826")]
    public void PersonNumberValidator_IsValidPersonNumber_Expect_Valid_True_Multiple_Input(string input)
    {
        var result = PersonNumberValidator.IsValidPersonNumber(input);
        Assert.True(result);
    }
}