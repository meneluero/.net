namespace KalkulatorApp;

// klasa korzysta z Calculator zamiast dziedziczenia po nim
public class ScientificCalculator
{
    private Calculator calculator;

    public ScientificCalculator(Calculator calc)
    {
        calculator = calc;
    }

    // zwraca podstawowy kalkulator zeby CalculatorService mial do niego dostep
    public Calculator GetCalculator()
    {
        return calculator;
    }

    public double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }

    public double SquareRoot(double a)
    {
        // pierwiastek z ujemnej nie istnieje w rzeczywistych
        if (a < 0)
            throw new ArgumentException("Pierwiastek z liczby ujemnej nie istnieje.");

        return Math.Sqrt(a);
    }

    public double Log(double a)
    {
        if (a <= 0)
            throw new ArgumentException("Logarytm działa tylko dla liczb większych od 0.");

        return Math.Log(a);
    }
}