using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DTO.DTOS.BookDTOS;

namespace LibrarySystem.DTO.DTOS.AuthorDTOS
{
    public class AuthorFullDto
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

        public virtual ICollection<BookFullDto> Books { get; set; } = new List<BookFullDto>();
    }
}
