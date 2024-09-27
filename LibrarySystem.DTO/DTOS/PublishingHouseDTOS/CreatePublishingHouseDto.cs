using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DTO.DTOS.PublishingHouseDTOS
{
    public class CreatePublishingHouseDto
    {
        public string PublishingHouseName { get; set; } = null!;

        public string? PublishingHouseAddress { get; set; }
    }
}
