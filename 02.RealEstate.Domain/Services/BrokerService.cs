using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;

namespace _02.RealEstate.Domain.Services
{
    public class BrokerService : IBrokerService
    {
        private readonly IBrokerRepository _repository;

        public BrokerService(IBrokerRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Get all the properties
        /// </summary>
        /// <returns>Task that returns a list of BrokerDTO</returns>
        public async Task<List<BrokerDTO>> GetAll()
        {
            var propertiesList = await _repository.GetAll();
            return Mapper.Map<List<Broker>, List<BrokerDTO>>(propertiesList);
        }

        /// <summary>
        /// Get a BrokerDTO by its Id
        /// </summary>
        /// <param name="id">Id of the broker to obtain</param>
        /// <returns>Task that returns a BrokerDTO entity</returns>
        public async Task<BrokerDTO> Get(int id)
        {
            var broker = await _repository.Get(id);
            return Mapper.Map<Broker, BrokerDTO>(broker);
        }
    }
}
