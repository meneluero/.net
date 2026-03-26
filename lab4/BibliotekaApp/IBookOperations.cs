namespace BibliotekaApp;

public interface IBookOperations
{
    bool BorrowBook(int bookId, string borrowerName);
    bool ReturnBook(int bookId);
}