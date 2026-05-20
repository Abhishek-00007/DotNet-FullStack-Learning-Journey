using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string conString =
        "Server=localhost,1433;Database=NFSDB;User Id=sa;Password=AbhiShek@0011;TrustServerCertificate=True";
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        Console.WriteLine("Connection Opened");

        string query =
        "INSERT INTO Students(Name,Age) VALUES('Parth',25)";

        SqlCommand cmd = new SqlCommand(query, con);

        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine($"{rows} row inserted");

        con.Close();
    }
}