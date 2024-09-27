using System;
using System.Collections.Generic;

namespace LibrarySystem.Entity.Model;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string AuthorSurname { get; set; } = null!;

    public int LogCreateUserId { get; set; }

    public DateTime LogCreateDate { get; set; }

    public int? LogUpdateUserId { get; set; }

    public DateTime? LogUpdateDate { get; set; }

    public int? LogDeleteUserId { get; set; }

    public DateTime? LogDeleteDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
