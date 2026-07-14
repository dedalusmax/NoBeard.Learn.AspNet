using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IConfiguration _configuration;

    public InvoiceRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Invoice> GetInvoices()
    {
        //var connectionString = "Server=(localdb)\\mssqllocaldb;Database=invoices;Trusted_Connection=true;";
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices ORDER BY InvoiceNumber", connection);

        using SqlDataReader reader = command.ExecuteReader();

        var result = new List<Invoice>();
        while (reader.Read())
        {
            var invoice = new Invoice
            {
                InvoiceNumber = reader.GetInt32(0),
                DateOfIssue = reader.GetDateTime(1)
            };
            result.Add(invoice);
        }

        //connection.Close();

        return result;
    }

    public Invoice? GetInvoiceById(int id)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices WHERE InvoiceNumber = @id", connection);
        //command.Parameters.Add(new SqlParameter("@id", id));        
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        return new Invoice
        {
            InvoiceNumber = reader.GetInt32(0),
            DateOfIssue = reader.GetDateTime(1)
        };
    }
}
