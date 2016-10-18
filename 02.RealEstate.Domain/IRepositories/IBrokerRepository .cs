using System.Collections.Generic;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;

namespace _02.RealEstate.Domain.IRepositories
{
    public interface IBrokerRepository
    {
        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of Broker</returns>
        Task<List<Broker>> GetAll();

        /// <summary>
        /// Get a Broker by its Id
        /// </summary>
        /// <param name="id">Id of the broker to obtain</param>
        /// <returns>Task that returns a Broker entity</returns>
        Task<Broker> Get(int id);

        /// <summary>
        /// Add a new broker
        /// </summary>
        /// <param name="broker">Broker entity with all the information to add</param>
        void Add(Broker broker);

        /// <summary>
        /// Update a given broker by its Id
        /// </summary>
        /// <param name="broker">Broker entity with all the information to update</param>
        void Update(Broker broker);

        /// <summary>
        /// Delete a broker by using its Id
        /// </summary>
        /// <param name="id">Id of the broker to delete</param>
        void Delete(int id);
    }
}
