﻿using LibrarySystem.Business.IService;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.IService
{
    public interface IPublishingHouseService : IGenericService<PublishingHouse>
    {
        PublishingHouse TGetByPublishingHouseName(string publishingHouseName);
        int TCreateByPublishingHouseName(string publishingHouseName);
    }
}
