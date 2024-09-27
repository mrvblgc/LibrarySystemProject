using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess.IRepositories
{
    public interface IUserRepository :IGenericRepository<UserInfo>
    {
        UserInfo GetByEmailPassword(string email, string password);
    }
}
