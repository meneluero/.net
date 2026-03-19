using System;
using System.Collections.Generic;
using System.Linq;

public static class TextAnalyzer
{
    public static int CountCharacters(string text)
    {
        if (text == null) return 0;
        return text.Length;
    }

    public static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;

        return text
            .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new string(w.Where(c => char.IsLetterOrDigit(c)).ToArray()))
            .Where(w => !string.IsNullOrEmpty(w))
            .Count();
    }

    public static int CountSentences(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Count(c => c == '.' || c == '!' || c == '?');
    }

    public static string FindMostCommonWord(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;

        var words = SplitIntoWords(text);
        if (words.Length == 0) return string.Empty;

        return words
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
    }

    public static TextStatistics AnalyzeText(string text)
    {
        var stats = new TextStatistics();

        if (string.IsNullOrEmpty(text))
            return stats;

        stats.CharacterCount = text.Length;
        stats.CharacterCountNoSpaces = text.Count(c => !char.IsWhiteSpace(c));
        stats.LetterCount = text.Count(char.IsLetter);
        stats.DigitCount = text.Count(char.IsDigit);
        stats.PunctuationCount = text.Count(char.IsPunctuation);

        var words = SplitIntoWords(text);
        stats.WordCount = words.Length;
        stats.UniqueWordCount = words.Distinct().Count();
        stats.MostCommonWord = FindMostCommonWord(text);

        if (words.Length > 0)
        {
            stats.AverageWordLength = (float)words.Average(w => w.Length);
            stats.LongestWord = words.OrderByDescending(w => w.Length).First();
            stats.ShortestWord = words.OrderBy(w => w.Length).First();
        }

        stats.SentenceCount = CountSentences(text);

        if (stats.SentenceCount > 0)
        {
            stats.AverageWordsPerSentence = (float)stats.WordCount / stats.SentenceCount;

            var rawSentences = text
                .Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));

            stats.LongestSentence = rawSentences
                .OrderByDescending(s =>
                    s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length)
                .First();
        }

        return stats;
    }

    private static string[] SplitIntoWords(string text)
    {
        return text
            .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new string(w.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower())
            .Where(w => !string.IsNullOrEmpty(w))
            .ToArray();
    }
}
