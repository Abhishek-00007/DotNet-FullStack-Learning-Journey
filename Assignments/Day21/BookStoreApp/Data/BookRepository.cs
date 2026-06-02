using Microsoft.Data.SqlClient;
using BookStoreApp.Models;
using System.Data;

namespace BookStoreApp.Data;

public class BookRepository
{
    private readonly string _connectionString;

    public BookRepository(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("DefaultConnection");
    }

    public List<Book> GetAllBooks()
    {
        List<Book> books = new();

        using SqlConnection con =
            new SqlConnection(_connectionString);

        string query = "SELECT * FROM Books";

        SqlCommand cmd = new SqlCommand(query, con);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            books.Add(new Book
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString()!,
                Author = reader["Author"].ToString()!,
                Price = Convert.ToDecimal(reader["Price"])
            });
        }

        return books;
    }

    //ADD BOOK
    public void AddBook(Book book)
    {
        using SqlConnection con =
            new SqlConnection(_connectionString);

        string query =
            "INSERT INTO Books(Title, Author, Price) VALUES(@Title, @Author, @Price)";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    //UPDATE BOOK
    public void UpdateBook(Book book)
    {
    using SqlConnection con =
        new SqlConnection(_connectionString);

    string query =
        @"UPDATE Books
          SET Title=@Title,
              Author=@Author,
              Price=@Price
          WHERE Id=@Id";

    SqlCommand cmd = new SqlCommand(query, con);

    cmd.Parameters.AddWithValue("@Id", book.Id);
    cmd.Parameters.AddWithValue("@Title", book.Title);
    cmd.Parameters.AddWithValue("@Author", book.Author);
    cmd.Parameters.AddWithValue("@Price", book.Price);

    con.Open();
    cmd.ExecuteNonQuery();
    }
    public Book? GetBookById(int id)
    {
        using SqlConnection con =
        new SqlConnection(_connectionString);

        string query =
            "SELECT * FROM Books WHERE Id=@Id";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Id", id);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Book
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString()!,
                Author = reader["Author"].ToString()!,
                Price = Convert.ToDecimal(reader["Price"])
            };
        }
        return null;
    }

    //DELETE BOOK
    public void DeleteBook(int id)
    {
        using SqlConnection con =
            new SqlConnection(_connectionString);

        string query =
            "DELETE FROM Books WHERE Id=@Id";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Id", id);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void AddBookSP(Book book)
    {
        using SqlConnection con =
            new SqlConnection(_connectionString);

        SqlCommand cmd =
            new SqlCommand("sp_AddBook", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public DataSet GetBooksDataSet()
    {
        using SqlConnection con =
            new SqlConnection(_connectionString);

        SqlDataAdapter adapter =
            new SqlDataAdapter(
                "SELECT * FROM Books",
                con);

        DataSet ds = new DataSet();

        adapter.Fill(ds, "Books");

        return ds;
    }

    public void UpdateDataSet(DataSet ds)
    {
        using SqlConnection con =
            new SqlConnection(_connectionString);

        SqlDataAdapter adapter =
            new SqlDataAdapter(
                "SELECT * FROM Books",
                con);

        SqlCommandBuilder builder =
            new SqlCommandBuilder(adapter);

        adapter.Update(ds, "Books");
    }
}
