using LibraryManagement.Models;

Library library = new Library();

Book book1 = new Book("Atomic Habits", "James Clear", "101");

Borrower borrower1 = new Borrower("Abhishek", "C001");

library.AddBook(book1);

library.RegisterBorrower(borrower1);

library.BorrowBook("101", "C001");

Console.WriteLine("Books:");

foreach (var book in library.ViewBooks())
{
    Console.WriteLine($"{book.Title} - Borrowed: {book.IsBorrowed}");
}

Console.WriteLine();

Console.WriteLine("Borrowers:");

foreach (var borrower in library.ViewBorrowers())
{
    Console.WriteLine($"{borrower.Name}");

    foreach (var borrowedBook in borrower.BorrowedBooks)
    {
        Console.WriteLine($"  {borrowedBook.Title}");
    }
}