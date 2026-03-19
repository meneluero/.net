namespace KalkulatorApp;

public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Nie można dzielić przez zero.");

        return a / b;
    }

    // sumowanie listy liczb
    public double SumSequence(IEnumerable<double> numbers)
    {
        double suma = 0;
        foreach (double n in numbers)
            suma += n;
        return suma;
    }

    public double Average(IEnumerable<double> numbers)
    {
        List<double> lista = numbers.ToList();
        if (lista.Count == 0)
            throw new InvalidOperationException("Lista jest pusta.");

        // uzywam SumSequence zamiast liczyc od nowa
        double suma = SumSequence(lista);
        return suma / lista.Count;
    }

    public double Max(IEnumerable<double> numbers)
    {
        List<double> lista = numbers.ToList();
        if (lista.Count == 0)
            throw new InvalidOperationException("Lista jest pusta.");

        // zaczynam od pierwszego elementu i porownuje z reszta
        double max = lista[0];
        foreach (double n in lista)
        {
            if (n > max)
                max = n;
        }
        return max;
    }

    public double Min(IEnumerable<double> numbers)
    {
        List<double> lista = numbers.ToList();
        if (lista.Count == 0)
            throw new InvalidOperationException("Lista jest pusta.");

        double min = lista[0];
        foreach (double n in lista)
        {
            if (n < min)
                min = n;
        }
        return min;
    }
}