using System.ComponentModel.DataAnnotations;

namespace NoBeard.Learn.AspNet.MvcApp.Models;

public class Pet
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    public int PetShopId { get; set; }

    [Required]
    public virtual PetShop PetShop { get; set; }

    public int PetTypeId { get; set; }

    [Required]
    public virtual PetType PetType { get; set; }
}
