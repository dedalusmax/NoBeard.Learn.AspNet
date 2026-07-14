using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    public Invoice? GetInvoiceById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Invoice> GetInvoices()
    {
        throw new NotImplementedException();
    }
}
