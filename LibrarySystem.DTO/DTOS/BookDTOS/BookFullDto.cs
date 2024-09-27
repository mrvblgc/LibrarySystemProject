using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DTO.DTOS.AuthorDTOS;
using LibrarySystem.DTO.DTOS.PublishingHouseDTOS;

namespace LibrarySystem.DTO.DTOS.BookDTOS
{
    public class BookFullDto
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

        public AuthorFullDto Author { get; set; } = null!;

        public  PublishingHouseFullDto PublishingHouse { get; set; } = null!;
    }
}
