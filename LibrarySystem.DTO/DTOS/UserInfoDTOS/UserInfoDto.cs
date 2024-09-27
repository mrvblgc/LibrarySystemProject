using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.UserInfoDTOS
{
    public class UserInfoDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Password { get; set; } = null!;

        public int UserRoleId { get; set; }
    }
}
