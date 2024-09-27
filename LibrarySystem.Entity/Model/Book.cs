using System;
using System.Collections.Generic;

namespace LibrarySystem.Entity.Model;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public decimal BookPrice { get; set; }

    public int? BookPage { get; set; }

    public int PublishingHouseId { get; set; }

    public int AuthorId { get; set; }

    public int LogCreateUserId { get; set; }

    public DateTime LogCreateDate { get; set; }

    public int? LogUpdateUserId { get; set; }

    public DateTime? LogUpdateDate { get; set; }

    public int? LogDeleteUserId { get; set; }

    public DateTime? LogDeleteDate { get; set; }

    public bool Active { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual PublishingHouse PublishingHouse { get; set; } = null!;
}
