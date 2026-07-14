using System.ComponentModel;

namespace NoBeard.Learn.AspNet.Domain.Models;

public class Invoice
{
    [DisplayName("Invoice Number")]
    public int InvoiceNumber { get; set; }

    [DisplayName("Date of Issue")]
    public DateTime DateOfIssue { get; set; }
}
