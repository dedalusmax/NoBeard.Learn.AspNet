namespace NoBeard.Learn.AspNet.MvcApp.Models;

public class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public List<AccountTransaction> Transactions { get; set; } = [];
}

public class AccountTransaction
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string? Note { get; set; }
}
