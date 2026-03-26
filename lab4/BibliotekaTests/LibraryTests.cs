using BibliotekaApp;

namespace BibliotekaTests;

public class LibraryTests
{
    // helper - tworzy biblioteke z jedna ksiazka zeby nie powtarzac kodu
    private Library StworzBiblioteke()
    {
        Library biblioteka = new Library();
        biblioteka.AddBook(new Book(1, "Testowa Książka", "Autor"));
        return biblioteka;
    }

    [Fact]
    public void BorrowBook_ReturnsTrue_WhenAvailable()
    {
        Library biblioteka = StworzBiblioteke();
        bool wynik = biblioteka.BorrowBook(1, "Kamil");
        Assert.True(wynik);
    }

    [Fact]
    public void BorrowBook_BookBecomesUnavailable()
    {
        Library biblioteka = StworzBiblioteke();
        biblioteka.BorrowBook(1, "Kamil");

        List<Book> dostepne = biblioteka.ListAvailableBooks();
        Assert.Empty(dostepne);
    }

    [Fact]
    public void BorrowBook_ThrowsException_WhenAlreadyBorrowed()
    {
        Library biblioteka = StworzBiblioteke();
        biblioteka.BorrowBook(1, "Kamil");

        // druga proba wypozyczenia tej samej ksiazki powinna rzucic wyjatek
        Assert.Throws<InvalidOperationException>(() => biblioteka.BorrowBook(1, "Kacper"));
    }

    [Fact]
    public void BorrowBook_ThrowsException_WhenBookNotFound()
    {
        Library biblioteka = StworzBiblioteke();
        Assert.Throws<ArgumentException>(() => biblioteka.BorrowBook(99, "Kamil"));
    }

    [Fact]
    public void ReturnBook_ReturnsTrue_WhenBorrowed()
    {
        Library biblioteka = StworzBiblioteke();
        biblioteka.BorrowBook(1, "Kamil");

        bool wynik = biblioteka.ReturnBook(1);
        Assert.True(wynik);
    }

    [Fact]
    public void ReturnBook_BookBecomesAvailable()
    {
        Library biblioteka = StworzBiblioteke();
        biblioteka.BorrowBook(1, "Kamil");
        biblioteka.ReturnBook(1);

        List<Book> dostepne = biblioteka.ListAvailableBooks();
        Assert.Single(dostepne);
    }

    [Fact]
    public void ReturnBook_ThrowsException_WhenNotBorrowed()
    {
        Library biblioteka = StworzBiblioteke();

        // ksiazka nie byla wypozyczona, zwrot powinien rzucic wyjatek
        Assert.Throws<InvalidOperationException>(() => biblioteka.ReturnBook(1));
    }
}