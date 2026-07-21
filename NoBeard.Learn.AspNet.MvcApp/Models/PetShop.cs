using System.ComponentModel.DataAnnotations;

namespace NoBeard.Learn.AspNet.MvcApp.Models;

public class PetShop
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, StringLength(250)]
    public required string Address { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = [];
}
