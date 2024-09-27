using LibrarySystem.DataAccess.Context;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibrarySystemContext _context;
        public DbSet<UserInfo> Table { get => _context.Set<UserInfo>(); }
        public UserRepository(LibrarySystemContext context)
        {
            _context = context;
        }
        public bool Create(UserInfo entity)
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
            var userInfo = Table.Find(id);
            if (userInfo != null)
            {
                userInfo.LogDeleteDate = DateTime.Now;
                userInfo.LogDeleteUserId = 0;
                userInfo.Active = false;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        public UserInfo GetById(int id)
        {
            return Table.Where(x => x.UserId == id && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<UserInfo> GetList()
        {
            return Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).ToList();
        }

        public bool Update(UserInfo entity)
        {
            var userInfo = GetById(entity.UserId);
            if (userInfo != null)
            {
                userInfo.Name = entity.Name;
                userInfo.Surname = entity.Surname;
                userInfo.Email = entity.Email;
                userInfo.PhoneNumber = entity.PhoneNumber;
                userInfo.Password = entity.Password;
                userInfo.UserRoleId = entity.UserRoleId;
                userInfo.LogUpdateDate = DateTime.Now;
                userInfo.LogUpdateUserId = 0;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        public UserInfo GetByEmailPassword(string email, string password)
        {
            var test = Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null && x.Email == email && x.Password == password).FirstOrDefault();
            return test;
        }
    }
}
