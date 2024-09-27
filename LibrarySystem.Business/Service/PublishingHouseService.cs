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
    public class PublishingHouseService : IPublishingHouseService
    {
        private readonly IPublishingHouseRepository _repository;
        public PublishingHouseService(IPublishingHouseRepository _publishRepository)
        {
            _repository = _publishRepository;
        }

        public bool TCreate(PublishingHouse entity)
        {
            return _repository.Create(entity);
        }

        public int TCreateByPublishingHouseName(string publishingHouseName)
        {
            return _repository.CreateByPublishingHouseName(publishingHouseName);
        }

        public bool TDelete(int id)
        {
            return _repository.Delete(id);
        }

        public PublishingHouse TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public PublishingHouse TGetByPublishingHouseName(string publishingHouseName)
        {
            return _repository.GetByPublishingHouseName(publishingHouseName);
        }

        public List<PublishingHouse> TGetList()
        {
            return _repository.GetList();
        }

        public bool TUpdate(PublishingHouse entity)
        {
            return _repository.Update(entity);
        }
    }
}
