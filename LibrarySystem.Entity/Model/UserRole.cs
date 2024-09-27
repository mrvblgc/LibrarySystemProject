using System;
using System.Collections.Generic;

namespace LibrarySystem.Entity.Model;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string UserRoleName { get; set; } = null!;

    public bool FullAuthority { get; set; }

    public int LogCreateUserId { get; set; }

    public DateTime LogCreateDate { get; set; }

    public int? LogUpdateUserId { get; set; }

    public DateTime? LogUpdateDate { get; set; }

    public int? LogDeleteUserId { get; set; }

    public DateTime? LogDeleteDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
}
