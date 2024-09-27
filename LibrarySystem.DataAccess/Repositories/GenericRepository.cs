using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.Repositories
{
    public class GenericRepository<T>(LibrarySystemContext _context) : IGenericRepository<T> where T : class
    {
        public DbSet<T> Table { get => _context.Set<T>(); }

        public bool Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges(); 
            return true;
        }
    }
}
