using System;
using System.Collections.Generic;

namespace LibrarySystem.Entity.Model;

public partial class PublishingHouse
{
    public int PublishingHouseId { get; set; }

    public string PublishingHouseName { get; set; } = null!;

    public string? PublishingHouseAddress { get; set; }

    public int LogCreateUserId { get; set; }

    public DateTime LogCreateDate { get; set; }

    public int? LogUpdateUserId { get; set; }

    public DateTime? LogUpdateDate { get; set; }

    public int? LogDeleteUserId { get; set; }

    public DateTime? LogDeleteDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
