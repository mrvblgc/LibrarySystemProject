using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.BookDTOS
{
    public class CreateBookExcelDto
    {
        public string BookName { get; set; } = null!;

        public decimal BookPrice { get; set; }

        public string PublishingHouseName { get; set; } = null!;

        public string AuthorName { get; set; } = null!;
        public string AuthorSurname { get; set; } = null!;
    }
}
