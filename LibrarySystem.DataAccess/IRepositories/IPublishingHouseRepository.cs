using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.IRepositories
{
    public interface IPublishingHouseRepository : IGenericRepository<PublishingHouse>
    {
        PublishingHouse GetByPublishingHouseName(string publishingHouseName);

        int CreateByPublishingHouseName(string publishingHouseName);
    }
}
