using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.UserRoleDTOS
{
    public class UpdateUserRoleDto
    {
        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; } = null!;

        public bool FullAuthority { get; set; }
    }
}
