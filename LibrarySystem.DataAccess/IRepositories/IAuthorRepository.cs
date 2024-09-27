using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.IRepositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Author GetByAuthorFullName(string authorName, string authorSurname);
        int CreateByAuthorFullName(string authorName, string authorSurname);
    }
}
