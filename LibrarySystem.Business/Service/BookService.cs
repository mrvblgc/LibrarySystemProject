using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;

namespace LibrarySystem.Business.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository _bookRepository)
        {
            _repository = _bookRepository;
        }
        public bool TCreate(Book entity)
        {
            return _repository.Create(entity);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Book> TGetBookInfoList()
        {
            return _repository.GetBookInfoList();
        }

        public Book TGetByBookName(string bookName)
        {
            return _repository.GetByBookName(bookName);
        }

        public Book TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Book> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(Book entity)
        {
           return _repository.Update(entity);
        }
    }
}
