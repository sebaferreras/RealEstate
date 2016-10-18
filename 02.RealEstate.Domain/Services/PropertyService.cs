using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;

namespace _02.RealEstate.Domain.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of PropertyListItemDTO</returns>
        public async Task<List<PropertyListItemDTO>> GetAll()
        {
            var propertiesList = await _repository.GetAll();
            return Mapper.Map<List<Property>, List<PropertyListItemDTO>>(propertiesList);
        }

        /// <summary>
        /// Get a PropertyDTO by its Id
        /// </summary>
        /// <param name="id">Id of the property to obtain</param>
        /// <returns>Task that returns a PropertyDTO entity</returns>
        public async Task<PropertyDTO> Get(int id)
        {
            var property = await _repository.Get(id);
            return Mapper.Map<Property, PropertyDTO>(property);
        }
    }
}
