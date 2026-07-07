namespace NoBeard.Learn.AspNet.Domain.Models;

public class Bank : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }
}
