using NUnit.Framework;
using LibraryManagement.Models;

namespace LibraryManagement.Tests;

public class LibraryTests
{
    private Library _library;

    [SetUp]
    public void Setup()
    {
        _library = new Library();
    }

    [Test]
    public void AddBook_ShouldAddBookToLibrary()
    {
        Book book = new Book("Clean Code", "Robert Martin", "111");

        _library.AddBook(book);

        Assert.That(_library.Books.Count, Is.EqualTo(1));
    }

    [Test]
    public void RegisterBorrower_ShouldRegisterBorrower()
    {
        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.RegisterBorrower(borrower);

        Assert.That(_library.Borrowers.Count, Is.EqualTo(1));
    }

    [Test]
    public void BorrowBook_ShouldMarkBookAsBorrowed()
    {
        Book book = new Book("C# Basics", "John", "222");

        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.AddBook(book);

        _library.RegisterBorrower(borrower);

        _library.BorrowBook("222", "C001");

        Assert.That(book.IsBorrowed, Is.True);
    }

    [Test]
    public void BorrowBook_ShouldAssociateBookWithBorrower()
    {
        Book book = new Book("C# Basics", "John", "222");

        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.AddBook(book);

        _library.RegisterBorrower(borrower);

        _library.BorrowBook("222", "C001");

        Assert.That(borrower.BorrowedBooks.Contains(book), Is.True);
    }

    [Test]
    public void ReturnBook_ShouldMarkBookAsAvailable()
    {
        Book book = new Book("C# Basics", "John", "222");

        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.AddBook(book);

        _library.RegisterBorrower(borrower);

        _library.BorrowBook("222", "C001");

        _library.ReturnBook("222", "C001");

        Assert.That(book.IsBorrowed, Is.False);
    }

    [Test]
    public void ReturnBook_ShouldRemoveBookFromBorrower()
    {
        Book book = new Book("C# Basics", "John", "222");

        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.AddBook(book);

        _library.RegisterBorrower(borrower);

        _library.BorrowBook("222", "C001");

        _library.ReturnBook("222", "C001");

        Assert.That(borrower.BorrowedBooks.Contains(book), Is.False);
    }

    [Test]
    public void ViewBooks_ShouldReturnBooksList()
    {
        Book book = new Book("Book1", "Author1", "333");

        _library.AddBook(book);

        var books = _library.ViewBooks();

        Assert.That(books.Count, Is.EqualTo(1));
    }

    [Test]
    public void ViewBorrowers_ShouldReturnBorrowersList()
    {
        Borrower borrower = new Borrower("Abhishek", "C001");

        _library.RegisterBorrower(borrower);

        var borrowers = _library.ViewBorrowers();

        Assert.That(borrowers.Count, Is.EqualTo(1));
    }
}