using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.IRepositories
{
    public interface IBookRepository :IGenericRepository<Book>
    {
        Book GetByBookName(string bookName);

        List<Book> GetBookInfoList();
    }
}
