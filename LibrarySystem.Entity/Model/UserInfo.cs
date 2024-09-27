using System;
using System.Collections.Generic;

namespace LibrarySystem.Entity.Model;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Password { get; set; } = null!;

    public int UserRoleId { get; set; }

    public int LogCreateUserId { get; set; }

    public DateTime LogCreateDate { get; set; }

    public int? LogUpdateUserId { get; set; }

    public DateTime? LogUpdateDate { get; set; }

    public int? LogDeleteUserId { get; set; }

    public DateTime? LogDeleteDate { get; set; }

    public bool Active { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
