using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;

namespace _02.RealEstate.Domain.Services
{
    public class PropertyService : IPropertyService
    {
        private IPropertyRepository repository;

        public PropertyService(IPropertyRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<Property> GetAll()
        {
            return repository.GetAll();
        }
    }
}
