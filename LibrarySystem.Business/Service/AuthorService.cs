using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository _authorRepository)
        {
            _repository = _authorRepository;
        }

        public bool TCreate(Author entity)
        {
            return _repository.Create(entity);
        }

        public int TCreateByAuthorFullName(string authorName, string authorSurname)
        {
            return _repository.CreateByAuthorFullName(authorName, authorSurname);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }

        public Author TGetByAuthorFullName(string authorName, string authorSurname)
        {
            return _repository.GetByAuthorFullName(authorName, authorSurname);
        }

        public Author TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Author> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(Author entity)
        {
            return _repository.Update(entity);
        }
    }
}
