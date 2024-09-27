using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.AuthorDTOS
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;

        public string AuthorSurname { get; set; } = null!;
    }
}
