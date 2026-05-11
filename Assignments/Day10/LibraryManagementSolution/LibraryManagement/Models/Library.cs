namespace LibraryManagement.Models;

public class Library
{
    public List<Book> Books { get; set; }
    public List<Borrower> Borrowers { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Borrowers = new List<Borrower>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RegisterBorrower(Borrower borrower)
    {
        Borrowers.Add(borrower);
    }

    public void BorrowBook(string isbn, string libraryCardNumber)
    {
        Book? book = Books.FirstOrDefault(b => b.ISBN == isbn);

        Borrower? borrower =
            Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

        if (book != null && borrower != null && !book.IsBorrowed)
        {
            book.Borrow();
            borrower.BorrowBook(book);
        }
    }

    public void ReturnBook(string isbn, string libraryCardNumber)
    {
        Book? book = Books.FirstOrDefault(b => b.ISBN == isbn);

        Borrower? borrower =
            Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

        if (book != null && borrower != null && book.IsBorrowed)
        {
            book.Return();
            borrower.ReturnBook(book);
        }
    }

    public List<Book> ViewBooks()
    {
        return Books;
    }

    public List<Borrower> ViewBorrowers()
    {
        return Borrowers;
    }
}