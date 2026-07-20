using System;
using System.Collections.Generic;

namespace NoBeard.Learn.AspNet.MvcApp.Models;

public partial class Book
{
    public int BookId { get; set; }

    public int Author { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int? Stock { get; set; }

    public DateTime ReleaseDate { get; set; }

    public virtual Author AuthorNavigation { get; set; } = null!;
}
