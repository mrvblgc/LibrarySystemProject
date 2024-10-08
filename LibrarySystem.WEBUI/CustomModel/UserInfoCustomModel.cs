﻿namespace LibrarySystem.WEBUI.CustomModel
{
    public class UserInfoCustomModel
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Password { get; set; } = null!;

        public int UserRoleId { get; set; }

    }
}
