using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Dtos;

namespace _02.RealEstate.Domain.IServices
{
    public interface IBrokerService
    {
        /// <summary>
        /// Get all the brokers
        /// </summary>
        /// <returns>Task that returns a list of BrokerDTO</returns>
        Task<List<BrokerDTO>> GetAll();

        /// <summary>
        /// Get a BrokerDTO by its Id
        /// </summary>
        /// <param name="id">Id of the borker to obtain</param>
        /// <returns>Task that returns a BrokerDTO entity</returns>
        Task<BrokerDTO> Get(int id);
    }
}
