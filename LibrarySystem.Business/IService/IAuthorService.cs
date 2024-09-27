using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.IService
{
    public interface IAuthorService :IGenericService<Author>
    {
        Author TGetByAuthorFullName(string authorName, string authorSurname);
        int TCreateByAuthorFullName(string authorName, string authorSurname);
    }
}
