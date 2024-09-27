using LibrarySystem.Business.IService;
using LibrarySystem.DataAccess.IRepositories;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.Entity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Service
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository _userRepository)
        {
            _repository = _userRepository;
        }

        public bool TCreate(UserInfo entity)
        {
            return _repository.Create(entity);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }

        public UserInfo TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public UserInfo TGetByEmailPassword(string email, string password)
        {
            return _repository.GetByEmailPassword(email,password);
        }

        public List<UserInfo> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(UserInfo entity)
        {
            return _repository.Update(entity);
        }
    }
}
