using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.IService
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();
        T TGetById(int id);
        bool TCreate(T entity);
        bool TUpdate(T entity);
        bool TDelete(int id);

    }
}
