namespace NoBeard.Learn.AspNet.Domain.Models;

public class InvoiceItem
{
    public int ID { get; set; }

    public int InvoiceNumber { get; set; }

    public string Title { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }
}
