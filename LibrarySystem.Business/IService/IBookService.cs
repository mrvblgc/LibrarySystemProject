using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.IService
{
    public interface IBookService : IGenericService<Book>
    {
        Book TGetByBookName(string bookName);

        List<Book> TGetBookInfoList();
    }
}
