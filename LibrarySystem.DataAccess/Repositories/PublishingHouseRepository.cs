using LibrarySystem.DataAccess.Context;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.Repositories
{
    public class PublishingHouseRepository : IPublishingHouseRepository
    {
        private readonly LibrarySystemContext _context;
        public DbSet<PublishingHouse> Table { get => _context.Set<PublishingHouse>(); }
        public PublishingHouseRepository(LibrarySystemContext context)
        {
            _context = context;
        }
        public bool Create(PublishingHouse entity)
        {
            entity.LogCreateDate = DateTime.Now;
            entity.LogCreateUserId = 0; // burası login olan kişinin id'si
            entity.Active = true;
            Table.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var pusblishHouseInfo = Table.Find(id);
            if (pusblishHouseInfo != null)
            {
                pusblishHouseInfo.LogDeleteDate = DateTime.Now;
                pusblishHouseInfo.LogDeleteUserId = 0;
                pusblishHouseInfo.Active = false;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public PublishingHouse GetById(int id)
        {
            return Table.Where(x => x.PublishingHouseId == id && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<PublishingHouse> GetList()
        {
            return Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).ToList();
        }

        public bool Update(PublishingHouse entity)
        {
            var publishInfo = GetById(entity.PublishingHouseId);
            if (publishInfo != null)
            {
                publishInfo.PublishingHouseName = entity.PublishingHouseName;
                publishInfo.PublishingHouseAddress = entity.PublishingHouseAddress;
                publishInfo.PublishingHouseId = entity.PublishingHouseId;
                publishInfo.LogUpdateDate = DateTime.Now;
                publishInfo.LogUpdateUserId = 0;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public PublishingHouse GetByPublishingHouseName(string publishingHouseName)
        {
            return Table.Where(x => x.PublishingHouseName == publishingHouseName && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public int CreateByPublishingHouseName(string publishingHouseName)
        {
            PublishingHouse entity = new PublishingHouse();
            entity.PublishingHouseName = publishingHouseName;
            entity.LogCreateDate = DateTime.Now;
            entity.LogCreateUserId = 0;
            entity.Active = true;
            Table.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return entity.PublishingHouseId;
            }
            return -1;
        }
    }
}
