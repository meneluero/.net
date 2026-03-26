namespace BibliotekaApp;

// ebook dziedziczy po book i dodaje format pliku
public class EBook : Book
{
    public string FileFormat { get; private set; }

    public EBook(int id, string title, string author, string fileFormat)
        : base(id, title, author)
    {
        FileFormat = fileFormat;
    }

    // nadpisujemy DisplayInfo zeby pokazac format pliku
    public override void DisplayInfo()
    {
        string dostepnosc = IsAvailable ? "dostępna" : $"wypożyczona przez {GetBorrower()}";
        Console.WriteLine($"[{Id}] {Title} - {Author} | Format: {FileFormat} ({dostepnosc})");
    }
}