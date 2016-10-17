using System.Linq;
using _02.RealEstate.Domain.Entities;

namespace _02.RealEstate.Domain.IRepositories
{
    public interface IPropertyRepository
    {
        IQueryable<Property> GetAll();
    }
}
