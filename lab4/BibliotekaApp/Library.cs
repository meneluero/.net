namespace BibliotekaApp;

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> ListAvailableBooks()
    {
        List<Book> dostepne = new List<Book>();
        foreach (Book b in books)
        {
            if (b.IsAvailable)
                dostepne.Add(b);
        }
        return dostepne;
    }

    // szukanie ksiazki po id
    private Book FindBook(int bookId)
    {
        foreach (Book b in books)
        {
            if (b.Id == bookId)
                return b;
        }
        return null;
    }

    public bool BorrowBook(int bookId, string borrowerName)
    {
        Book ksiazka = FindBook(bookId);

        if (ksiazka == null)
            throw new ArgumentException("Nie znaleziono książki o podanym ID.");

        if (!ksiazka.IsAvailable)
            throw new InvalidOperationException($"Książka jest już wypożyczona przez {ksiazka.GetBorrower()}.");

        ksiazka.SetBorrower(borrowerName);
        return true;
    }

    public bool ReturnBook(int bookId)
    {
        Book ksiazka = FindBook(bookId);

        if (ksiazka == null)
            throw new ArgumentException("Nie znaleziono książki o podanym ID.");

        if (ksiazka.IsAvailable)
            throw new InvalidOperationException("Ta książka nie była wypożyczona.");

        ksiazka.SetReturned();
        return true;
    }
}