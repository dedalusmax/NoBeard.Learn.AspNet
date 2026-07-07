using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoBeard.Learn.AspNet.Domain.Models;

public class User : IEntity
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Ime")]
    public string FirstName { get; set; }

    [DisplayName("Prezime")]
    public string LastName { get; set; }

    public string? Address { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }
}
