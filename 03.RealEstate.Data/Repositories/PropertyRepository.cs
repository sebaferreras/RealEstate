using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _03.RealEstate.Data.Context;

namespace _03.RealEstate.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IRealStateContext _db;

        public PropertyRepository()
        {
            _db = new RealEstateContext();
        }

        public PropertyRepository(IRealStateContext realStateContext)
        {
            _db = realStateContext;
        }

        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of Property</returns>
        public Task<List<Property>> GetAll()
        {
            return _db.Properties.ToListAsync();
        }

        /// <summary>
        /// Get a Property by its Id
        /// </summary>
        /// <param name="id">Id of the property to obtain</param>
        /// <returns>Task that returns a Property entity</returns>
        public Task<Property> Get(int id)
        {
            return _db.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add a new property
        /// </summary>
        /// <param name="property">Property entity with all the information to add</param>
        public async void Add(Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Update a given property by its Id
        /// </summary>
        /// <param name="property">Property entity with all the information to update</param>
        public async void Update(Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete a property by using its Id
        /// </summary>
        /// <param name="id">Id of the property to delete</param>
        public async void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
