namespace BibliotekaApp;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IsAvailable { get; private set; }

    // kto aktualnie ma ksiazke
    private string borrowerName;

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
        IsAvailable = true;
        borrowerName = "";
    }

    public void SetBorrower(string name)
    {
        borrowerName = name;
        IsAvailable = false;
    }

    public void SetReturned()
    {
        borrowerName = "";
        IsAvailable = true;
    }

    public string GetBorrower()
    {
        return borrowerName;
    }

    public virtual void DisplayInfo()
    {
        string dostepnosc = IsAvailable ? "dostępna" : $"wypożyczona przez {borrowerName}";
        Console.WriteLine($"[{Id}] {Title} - {Author} ({dostepnosc})");
    }
}