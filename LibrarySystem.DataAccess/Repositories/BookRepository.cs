using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Context;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace LibrarySystem.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarySystemContext _context;
        public DbSet<Book> Table { get => _context.Set<Book>(); }
        public BookRepository(LibrarySystemContext context)
        {
            _context = context;
        }
        public bool Create(Book entity)
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
            var bookInfo = Table.Find(id);
            if (bookInfo != null)
            {
                bookInfo.LogDeleteDate = DateTime.Now;
                bookInfo.LogDeleteUserId = 0;
                bookInfo.Active = false;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Book GetById(int id)
        {
            return Table.Where(x => x.BookId == id && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<Book> GetList()
        {
            return Table.Where(x => x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).ToList();
        }

        public bool Update(Book entity)
        {
            var bookInfo = GetById(entity.BookId);
            if (bookInfo != null)
            {
                bookInfo.BookName = entity.BookName;
                bookInfo.BookPrice = entity.BookPrice;
                bookInfo.BookPage = entity.BookPage;
                bookInfo.AuthorId = entity.AuthorId;
                bookInfo.PublishingHouseId = entity.PublishingHouseId;
                bookInfo.LogUpdateDate = DateTime.Now;
                bookInfo.LogUpdateUserId = 0;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Book GetByBookName(string bookName)
        {
            return Table.Where(x => x.BookName == bookName && x.Active == true && x.LogDeleteUserId == null && x.LogDeleteDate == null).FirstOrDefault();
        }

        public List<Book> GetBookInfoList()
        {
            return Table.Where(x => x.Active && x.LogDeleteDate == null && x.LogDeleteUserId == null).ToList();

        }
    }
}
