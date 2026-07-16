using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.Domain.Repositories;

public interface IInvoiceRepository
{
    List<Invoice> GetInvoices();

    Invoice? GetInvoiceById(int id);

    int CreateInvoice(Invoice invoice);
}
