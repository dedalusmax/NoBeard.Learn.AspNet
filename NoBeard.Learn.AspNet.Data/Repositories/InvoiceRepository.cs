using Microsoft.Data.SqlClient;
using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    public InvoiceRepository()
    {
    }

    public List<Invoice> GetInvoices()
    {
        var connectionString = "Server=(localdb)\\mssqllocaldb;Database=invoices;Trusted_Connection=true;";

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
        throw new NotImplementedException();
    }
}
