namespace KalkulatorApp;

public class CalculatorService
{
    private ScientificCalculator scientificCalculator;

    public CalculatorService(ScientificCalculator sc)
    {
        scientificCalculator = sc;
    }

    public void Run()
    {
        Console.WriteLine("Kalkulator naukowy w C#");

        while (true)
        {
            Console.WriteLine("\nWybierz operację: +, -, *, /, ^, sqrt, log, sum, avg, max, min, exit");
            Console.Write("> ");
            string operacja = Console.ReadLine().Trim().ToLower();

            if (operacja == "exit")
                break;

            try
            {
                WykonajOperacje(operacja);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
        }
    }

    private void WykonajOperacje(string operacja)
    {
        Calculator calc = scientificCalculator.GetCalculator();

        if (operacja == "+" || operacja == "-" || operacja == "*" || operacja == "/" || operacja == "^")
        {
            Console.Write("Podaj pierwszą liczbę: ");
            double a = PobierzLiczbe();

            Console.Write("Podaj drugą liczbę: ");
            double b = PobierzLiczbe();

            double wynik = 0;

            if (operacja == "+")
                wynik = calc.Add(a, b);
            else if (operacja == "-")
                wynik = calc.Subtract(a, b);
            else if (operacja == "*")
                wynik = calc.Multiply(a, b);
            else if (operacja == "/")
                wynik = calc.Divide(a, b);
            else if (operacja == "^")
                wynik = scientificCalculator.Power(a, b);

            Console.WriteLine("Wynik: " + wynik);
        }
        else if (operacja == "sqrt")
        {
            Console.Write("Podaj liczbę: ");
            double a = PobierzLiczbe();
            Console.WriteLine("Wynik: " + scientificCalculator.SquareRoot(a));
        }
        else if (operacja == "log")
        {
            Console.Write("Podaj liczbę: ");
            double a = PobierzLiczbe();
            Console.WriteLine("Wynik: " + scientificCalculator.Log(a));
        }
        else if (operacja == "sum" || operacja == "avg" || operacja == "max" || operacja == "min")
        {
            Console.WriteLine("Podaj liczby oddzielone spacją:");
            Console.Write("> ");
            string wejscie = Console.ReadLine();

            // parsowanie liczb z wejscia
            string[] czesci = wejscie.Split(' ');
            List<double> liczby = new List<double>();

            foreach (string s in czesci)
            {
                if (s.Trim() == "") continue;
                liczby.Add(double.Parse(s, System.Globalization.CultureInfo.InvariantCulture));
            }

            double wynik = 0;
            if (operacja == "sum")
                wynik = calc.SumSequence(liczby);
            else if (operacja == "avg")
                wynik = calc.Average(liczby);
            else if (operacja == "max")
                wynik = calc.Max(liczby);
            else if (operacja == "min")
                wynik = calc.Min(liczby);

            Console.WriteLine("Wynik: " + wynik);
        }
        else
        {
            Console.WriteLine("Nieznana operacja.");
        }
    }

    // pomocnicza metoda do wczytywania liczby
    private double PobierzLiczbe()
    {
        string wejscie = Console.ReadLine();
        if (!double.TryParse(wejscie, System.Globalization.CultureInfo.InvariantCulture, out double wynik))
            throw new FormatException("Podana wartość nie jest liczbą.");
        return wynik;
    }
}