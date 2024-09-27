using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Context;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace LibrarySystem.DataAccess.Repositories
{
    public class UserRoleRepository :IUserRoleRepository
    {
        private readonly LibrarySystemContext _context;
        public DbSet<UserRole> Table { get => _context.Set<UserRole>(); }
        public UserRoleRepository(LibrarySystemContext context)
        {
            _context = context;
        }
        public bool Create(UserRole entity)
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
            var userRoleInfo = Table.Find(id);
            if (userRoleInfo != null)
            {
                userRoleInfo.LogDeleteDate = DateTime.Now;
                userRoleInfo.LogDeleteUserId = 0;
                userRoleInfo.Active = false;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public UserRole GetById(int id)
        {
            return Table.Where(x => x.UserRoleId == id && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<UserRole> GetList()
        {
            return Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).ToList();
        }

        public bool Update(UserRole entity)
        {
            var userRoleInfo = GetById(entity.UserRoleId);
            if (userRoleInfo != null)
            {
                userRoleInfo.UserRoleName = entity.UserRoleName;
                userRoleInfo.FullAuthority = entity.FullAuthority;
                userRoleInfo.LogUpdateDate = DateTime.Now;
                userRoleInfo.LogUpdateUserId = 0;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
