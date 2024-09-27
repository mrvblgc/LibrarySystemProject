using LibrarySystem.DTO.DTOS.BookDTOS;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.PublishingHouseDTOS
{
    public class PublishingHouseFullDto
    {
        public int PublishingHouseId { get; set; }

        public string PublishingHouseName { get; set; } = null!;

        public string? PublishingHouseAddress { get; set; }

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
