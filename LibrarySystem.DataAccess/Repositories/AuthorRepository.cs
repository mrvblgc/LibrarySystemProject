using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Context;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibrarySystemContext _context;
        public DbSet<Author> Table { get => _context.Set<Author>(); }
        public AuthorRepository(LibrarySystemContext context)
        {
            _context = context;
        }
        public bool Create(Author entity)
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
            var authorInfo = Table.Find(id);
            if (authorInfo != null)
            {
                authorInfo.LogDeleteDate = DateTime.Now;
                authorInfo.LogDeleteUserId = 0;
                authorInfo.Active = false;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Author GetById(int id)
        {
            return Table.Where(x => x.AuthorId == id && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<Author> GetList()
        {
            return Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).ToList();
        }

        public bool Update(Author entity)
        {
            var authorInfo = GetById(entity.AuthorId);
            if (authorInfo != null)
            {
                authorInfo.AuthorName = entity.AuthorName;
                authorInfo.AuthorSurname = entity.AuthorSurname;
                authorInfo.LogUpdateDate = DateTime.Now;
                authorInfo.LogUpdateUserId = 0;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Author GetByAuthorFullName(string authorName, string authorSurname)
        {
            return Table.Where(x=>x.AuthorName.ToLower().Contains(authorName.ToLower()) && x.AuthorSurname.ToLower().Contains(authorSurname.ToLower()) && x.LogDeleteDate == null && x.LogDeleteUserId == null).FirstOrDefault();
        }

        public int CreateByAuthorFullName(string authorName, string authorSurname)
        {
            Author entity = new Author();
            entity.AuthorName = authorName;
            entity.AuthorSurname = authorSurname;
            entity.LogCreateDate = DateTime.Now;
            entity.LogCreateUserId = 0; // burası login olan kişinin id'si
            entity.Active = true;
            Table.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return entity.AuthorId;
            }
            return -1;
        }
    }
}
