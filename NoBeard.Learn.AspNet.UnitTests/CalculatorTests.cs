using NoBeard.Learn.AspNet.MvcApp.Test;
using System.Collections;

namespace NoBeard.Learn.AspNet.UnitTests;

public class CalculatorTests
{
    [Fact]
    public void TestCalculateVat_IntegerAmount_TaxCorrect()
    {
        // ARRANGE
        var calc = new Calculator();
        var input = 100;

        // ACT
        var result = calc.CalculateVat(input);

        // ASSERT
        Assert.IsType<double>(result);
        Assert.NotEqual(input, result);
        Assert.Equal(125, result);
    }

    [Fact]
    public void TestCalculateVat_DecimalPointAmount_TaxCorrect()
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        var result = calc.CalculateVat(5.42);

        // ASSERT
        Assert.Equal(6.78, result);
    }

    [Fact]
    public void TestCalculateVat_ZeroAmount_TaxCorrect()
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        var result = calc.CalculateVat(0);

        // ASSERT
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestCalculateVat_NegativeAmount_ThrowsException()
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        Action result = () => calc.CalculateVat(-4.25);

        // ASSERT
        Assert.Throws<ArgumentException>(result);
    }

    [Theory]
    [InlineData(100, 25, 125)]
    [InlineData(200, 25, 250)]
    [InlineData(0, 25, 0)]
    [InlineData(100, 12, 112)]
    [InlineData(50, 5, 52.5)]
    public void TestCalculateTax_TheoryInlineData_TaxCorrect(double amount, double tax, double expected)
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        var result = calc.CalculateTax(amount, tax);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void TestCalculateTax_TheoryClassData_TaxCorrect(double amount, double tax, double expected)
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        var result = calc.CalculateTax(amount, tax);

        // ASSERT
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void TestCalculateTax_TheoryMemberData_TaxCorrect(double amount, double tax, double expected)
    {
        // ARRANGE
        var calc = new Calculator();

        // ACT
        var result = calc.CalculateTax(amount, tax);

        // ASSERT
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetData()
    {
        return
        [
            [50, 25, 62.50],
            [100, 12, 112]
        ];
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 100, 25, 125 };
        yield return new object[] { 200, 25, 250 };
        yield return new object[] { 0, 25, 0 };
        yield return new object[] { 50, 5, 52.5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}