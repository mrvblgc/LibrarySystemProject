using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Service
{
    public class GenericService<T>(IGenericRepository<T> _repository) : IGenericService<T> where T : class
    {
        public bool TCreate(T entity)
        {
            return _repository.Create(entity);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }


        public T TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
