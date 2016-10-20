using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _03.RealEstate.Data.Context;

namespace _03.RealEstate.Data.Repositories
{
    public class BrokerRepository : IBrokerRepository
    {
        private readonly IRealStateContext _db;

        public BrokerRepository()
        {
            _db = new RealEstateContext();
        }

        public BrokerRepository(IRealStateContext realStateContext)
        {
            _db = realStateContext;
        }

        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of Broker</returns>
        public Task<List<Broker>> GetAll()
        {
            return _db.Brokers.ToListAsync();
        }

        /// <summary>
        /// Get a Broker by its Id
        /// </summary>
        /// <param name="id">Id of the broker to obtain</param>
        /// <returns>Task that returns a Broker entity</returns>
        public Task<Broker> Get(int id)
        {
            return _db.Brokers.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add a new broker
        /// </summary>
        /// <param name="broker">Broker entity with all the information to add</param>
        public async void Add(Broker broker)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Update a given broker by its Id
        /// </summary>
        /// <param name="broker">Broker entity with all the information to update</param>
        public async void Update(Broker broker)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete a broker by using its Id
        /// </summary>
        /// <param name="id">Id of the broker to delete</param>
        public async void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
