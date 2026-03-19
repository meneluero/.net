using KalkulatorApp;

namespace CalculatorTests;

public class CalculatorTests
{
    private Calculator kalkulator = new Calculator();

    [Fact]
    public void Add_ReturnsCorrectResult()
    {
        double wynik = kalkulator.Add(2, 3);
        Assert.Equal(5.0, wynik);
    }

    [Fact]
    public void Subtract_ReturnsCorrectResult()
    {
        double wynik = kalkulator.Subtract(10, 4);
        Assert.Equal(6.0, wynik);
    }

    [Fact]
    public void Multiply_ReturnsCorrectResult()
    {
        double wynik = kalkulator.Multiply(3, 4);
        Assert.Equal(12.0, wynik);
    }

    [Fact]
    public void Divide_ReturnsCorrectResult()
    {
        double wynik = kalkulator.Divide(10, 2);
        Assert.Equal(5.0, wynik);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => kalkulator.Divide(5, 0));
    }

    [Fact]
    public void SumSequence_ReturnsCorrectResult()
    {
        List<double> liczby = new List<double> { 1.2, 2.8, 3.5, 4 };
        double wynik = kalkulator.SumSequence(liczby);
        Assert.Equal(11.5, wynik);
    }

    [Fact]
    public void Average_ReturnsCorrectResult()
    {
        List<double> liczby = new List<double> { 2, 4, 6 };
        double wynik = kalkulator.Average(liczby);
        Assert.Equal(4.0, wynik);
    }

    [Fact]
    public void Max_ReturnsCorrectResult()
    {
        List<double> liczby = new List<double> { 1, 7, 3 };
        double wynik = kalkulator.Max(liczby);
        Assert.Equal(7.0, wynik);
    }

    [Fact]
    public void Min_ReturnsCorrectResult()
    {
        List<double> liczby = new List<double> { 1, 7, 3 };
        double wynik = kalkulator.Min(liczby);
        Assert.Equal(1.0, wynik);
    }
}  