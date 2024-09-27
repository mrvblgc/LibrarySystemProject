using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.BookDTOS
{
    public class BookDto
    {
        //public int BookId { get; set; }

        public string BookName { get; set; } = null!;

        public decimal BookPrice { get; set; }

        public int? BookPage { get; set; }

        public string AuthorName { get; set; } = null!;

        public string AuthorSurname { get; set; } = null!;

        public string PublishingHouseName { get; set; } = null!;

        public string? PublishingHouseAddress { get; set; }

    }
}
