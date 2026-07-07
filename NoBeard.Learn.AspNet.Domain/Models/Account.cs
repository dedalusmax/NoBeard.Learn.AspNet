using System.ComponentModel;

namespace NoBeard.Learn.AspNet.Domain.Models;

public class Account : IEntity
{
    public int Id { get; set; }

    [DisplayName("Naziv računa")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Saldo")]
    public decimal Total { get; set; }

    public List<AccountTransaction> Transactions { get; set; } = [];
}

public class AccountTransaction
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string? Note { get; set; }
}
