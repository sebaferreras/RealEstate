using System;
using System.Collections.Generic;
using System.Linq;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;

namespace _03.RealEstate.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public IQueryable<Property> GetAll()
        {
            var result = new List<Property>();
            
            result.Add(new Property
            {
                Id = 1,
                Title = "Condominium Redefined"
            });

            return result.AsQueryable();

            throw new NotImplementedException();
        }
    }
}
