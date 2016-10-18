using System.Collections.Generic;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;

namespace _02.RealEstate.Domain.IRepositories
{
    public interface IPropertyRepository
    {
        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of Property</returns>
        Task<List<Property>> GetAll();

        /// <summary>
        /// Get a Property by its Id
        /// </summary>
        /// <param name="id">Id of the property to obtain</param>
        /// <returns>Task that returns a Property entity</returns>
        Task<Property> Get(int id);

        /// <summary>
        /// Add a new property
        /// </summary>
        /// <param name="property">Property entity with all the information to add</param>
        void Add(Property property);

        /// <summary>
        /// Update a given property by its Id
        /// </summary>
        /// <param name="property">Property entity with all the information to update</param>
        void Update(Property property);

        /// <summary>
        /// Delete a property by using its Id
        /// </summary>
        /// <param name="id">Id of the property to delete</param>
        void Delete(int id);
    }
}
