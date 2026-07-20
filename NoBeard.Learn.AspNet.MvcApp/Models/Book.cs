using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoBeard.Learn.AspNet.MvcApp.Models;

public class Book
{
    [Required, DisplayName("Šifra knjige")]
    public int BookId { get; set; }
    
    [Required, DisplayName("Autor")]
    public int Author { get; set; }

    [Required, StringLength(255), DisplayName("Naslov")]
    public string Title { get; set; }
    
    [DisplayName("Opis")]
    public string Description { get; set; }

    [StringLength(255), DisplayName("Žanr")]
    public string Genre { get; set; }
    
    [DisplayName("Stanje")] 
    public int? Stock { get; set; }
    
    [DisplayName("Datum izlaska")]
    public DateTime ReleaseDate { get; set; }
}
