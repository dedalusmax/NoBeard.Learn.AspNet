using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;
using System.Data;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository, IDisposable
{
    private readonly SqlConnection _connection;

    public InvoiceRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public List<Invoice> GetInvoices()
    {
        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices ORDER BY InvoiceNumber", _connection);

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
        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices WHERE InvoiceNumber = @id", _connection);
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

    public int CreateInvoice(Invoice invoice)
    {
        using var command = new SqlCommand("INSERT INTO Invoices (DateOfIssue) VALUES (@dateOfIssue); SELECT SCOPE_IDENTITY();", _connection);
        command.Parameters.AddWithValue("@dateOfIssue", invoice.DateOfIssue);

        var result = command.ExecuteScalar();

        return Convert.ToInt32(result);
    }

    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
