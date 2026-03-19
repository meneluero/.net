using KalkulatorApp;

namespace CalculatorTests;

public class ScientificCalculatorTests
{
    private ScientificCalculator naukowy = new ScientificCalculator(new Calculator());

    [Fact]
    public void Power_ReturnsCorrectResult()
    {
        double wynik = naukowy.Power(2, 3);
        Assert.Equal(8.0, wynik);
    }

    [Fact]
    public void SquareRoot_ReturnsCorrectResult()
    {
        double wynik = naukowy.SquareRoot(9);
        Assert.Equal(3.0, wynik, precision: 5);
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        // sprawdzam czy metoda rzuca wyjatek dla liczby ujemnej
        Assert.Throws<ArgumentException>(() => naukowy.SquareRoot(-4));
    }

    [Fact]
    public void Log_ReturnsCorrectResult()
    {
        double wynik = naukowy.Log(1);
        Assert.Equal(0.0, wynik, precision: 5);
    }
}