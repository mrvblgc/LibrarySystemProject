using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.BookDTOS
{
    public class UpdateBookDto
    {
        public int BookId { get; set; }

        public string BookName { get; set; } = null!;

        public decimal BookPrice { get; set; }

        public int? BookPage { get; set; }

        public int PublishingHouseId { get; set; }

        public int AuthorId { get; set; }
    }
}
