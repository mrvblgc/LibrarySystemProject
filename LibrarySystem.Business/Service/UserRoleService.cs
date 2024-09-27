using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Service
{
    public class UserRoleService :IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        public UserRoleService(IUserRoleRepository _userRepository)
        {
            _repository = _userRepository;
        }
        public bool TCreate(UserRole entity)
        {
            return _repository.Create(entity);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }

        public UserRole TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<UserRole> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(UserRole entity)
        {
            return _repository.Update(entity);
        }
    }
}
