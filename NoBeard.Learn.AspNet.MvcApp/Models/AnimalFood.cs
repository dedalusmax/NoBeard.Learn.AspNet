using System.ComponentModel.DataAnnotations;

namespace NoBeard.Learn.AspNet.MvcApp.Models;

public class AnimalFood
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, Length(13, 13)]
    public required string Barcode { get; set; }

    [Required]
    public double Price { get; set; }
}
