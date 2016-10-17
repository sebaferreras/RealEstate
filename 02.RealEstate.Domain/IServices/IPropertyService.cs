using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;

namespace _02.RealEstate.Domain.IServices
{
    public interface IPropertyService
    {
        IQueryable<Property> GetAll();
    }
}
