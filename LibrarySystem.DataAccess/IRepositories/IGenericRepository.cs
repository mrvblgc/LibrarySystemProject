using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);

    }
}
