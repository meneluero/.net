using BibliotekaApp;

Library biblioteka = new Library();

biblioteka.AddBook(new Book(1, "3.0 Też Inżynier", "Weteran Sesji"));
biblioteka.AddBook(new Book(2, "Projekt_Final_v2_Ostateczny_Poprawiony", "Anonim z Laboratorium"));
biblioteka.AddBook(new EBook(3, "Jak udawać że rozumiesz OOP", "ChatGPT", "PDF"));

Console.WriteLine("Dostępne książki");
foreach (Book b in biblioteka.ListAvailableBooks())
    b.DisplayInfo();

// wypozyczenie
try
{
    biblioteka.BorrowBook(1, "Kamil");
    Console.WriteLine("\nKsiążka wypożyczona!");
}
catch (Exception ex)
{
    Console.WriteLine("Błąd: " + ex.Message);
}

// proba wypozyczenia tej samej ksiazki drugi raz
try
{
    biblioteka.BorrowBook(1, "Kacper");
}
catch (Exception ex)
{
    Console.WriteLine("Błąd: " + ex.Message);
}

// zwrot
try
{
    biblioteka.ReturnBook(1);
    Console.WriteLine("Książka zwrócona!");
}
catch (Exception ex)
{
    Console.WriteLine("Błąd: " + ex.Message);
}