using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string? text = null;

        if (args.Length > 0)
        {
            text = ReadFromFile(args[0]);
            if (text == null) return; 

        }
        else
        {

            Console.WriteLine("program do analizy tekstu");
            Console.WriteLine("wybierz co chcesz zrobic:");
            Console.WriteLine("  1 - wpisz tekst sam");
            Console.WriteLine("  2 - wczytaj z pliku");
            Console.Write("wybor: ");

            string? choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    text = ReadFromConsole();
                    break;

                case "2":
                    Console.Write("podaj sciezke do pliku: ");
                    string? path = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        Console.WriteLine("nie podales sciezki");
                        return;
                    }
                    text = ReadFromFile(path);
                    if (text == null) return;
                    break;

                default:
                    Console.WriteLine("zly wybor");
                    return;
            }
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("tekst jest pusty");
            return;
        }

        var stats = TextAnalyzer.AnalyzeText(text);
        PrintResults(stats);
    }

    private static string? ReadFromConsole()
    {
        Console.WriteLine("wpisz tekst (pusta linia = koniec):");
        var lines = new System.Text.StringBuilder();
        string? line;
        while ((line = Console.ReadLine()) != null && line != string.Empty)
            lines.AppendLine(line);

        string result = lines.ToString().Trim();
        if (string.IsNullOrWhiteSpace(result))
        {
            Console.WriteLine("nic nie wpisales");
            return null;
        }
        return result;
    }

    private static string? ReadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"nie ma takiego pliku: '{path}'");
            return null;
        }

        try
        {
            string content = File.ReadAllText(path, System.Text.Encoding.UTF8).Trim();
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("plik jest pusty");
                return null;
            }
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"nie udalo sie odczytac pliku: {ex.Message}");
            return null;
        }
    }

    private static void PrintResults(TextStatistics s)
    {
        Console.WriteLine();
        Console.WriteLine("--- wyniki ---");
        Console.WriteLine($"znaki (ze spacjami): {s.CharacterCount}");
        Console.WriteLine($"znaki (bez spacji): {s.CharacterCountNoSpaces}");
        Console.WriteLine($"litery: {s.LetterCount}");
        Console.WriteLine($"cyfry: {s.DigitCount}");
        Console.WriteLine($"znaki interpunkcyjne: {s.PunctuationCount}");
        Console.WriteLine("---");
        Console.WriteLine($"slowa: {s.WordCount}");
        Console.WriteLine($"unikalne slowa: {s.UniqueWordCount}");
        Console.WriteLine($"najczestsze slowo: {Truncate(s.MostCommonWord, 16)}");
        Console.WriteLine($"srednia dlugosc slowa: {s.AverageWordLength:F2}");
        Console.WriteLine($"najdluzsze slowo: {Truncate(s.LongestWord, 16)}");
        Console.WriteLine($"najkrotsze slowo: {Truncate(s.ShortestWord, 16)}");
        Console.WriteLine("---");
        Console.WriteLine($"zdania: {s.SentenceCount}");
        Console.WriteLine($"srednia slow na zdanie: {s.AverageWordsPerSentence:F2}");
        Console.WriteLine($"najdluzsze zdanie:");
        Console.WriteLine($"{Truncate(s.LongestSentence, 44)}");
    }

    private static string Truncate(string value, int max)
    {
        if (string.IsNullOrEmpty(value)) return "-";
        return value.Length <= max ? value : value[..(max - 1)] + "…";
    }
}