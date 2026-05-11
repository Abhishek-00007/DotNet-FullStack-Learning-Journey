using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string conString =
        "Server=.;Database=NFSDB;Trusted_Connection=True;TrustServerCertificate=True";

        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string query =
        "INSERT INTO Students(Name,Age) VALUES('Parth',25)";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.ExecuteNonQuery();

        Console.WriteLine("Record Inserted");

        con.Close();
    }
}