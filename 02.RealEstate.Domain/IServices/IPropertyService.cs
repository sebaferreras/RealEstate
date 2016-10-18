using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Dtos;

namespace _02.RealEstate.Domain.IServices
{
    public interface IPropertyService
    {
        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns q list of PropertyListItemDTO</returns>
        Task<List<PropertyListItemDTO>> GetAll();

        /// <summary>
        /// Get a PropertyDTO by its Id
        /// </summary>
        /// <param name="id">Id of the property to obtain</param>
        /// <returns>Task that returns a PropertyDTO entity</returns>
        Task<PropertyDTO> Get(int id);
    }
}
