using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using _02.RealEstate.Domain.Automapper;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.Entities.Mocks;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;
using _02.RealEstate.Domain.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _02.RealEstate.Domain.Tests.Services
{
    [TestFixture]
    public class BrokerServiceTest
    {
        // Mocks
        private Mock<IBrokerRepository> _brokerRepositoryMock;
        private IBrokerService _brokerServiceMock;
        private List<BrokerDTO> _brokerListDtoMock;
        private List<Broker> _brokerListMock;

        [SetUp]
        public void Initialize()
        {
            // Since the repository returns Broker entities but the service returns BrokerDTO entities we need to initialize Automapper
            AutomapperBootstrapper.Initialize();

            // Initialize the data we're going to use in the tests
            _brokerListMock = BrokerMocks.GetBrokerListMock();

            // Get the list of DTO's by using the moked list
            _brokerListDtoMock = Mapper.Map<List<Broker>, List<BrokerDTO>>(_brokerListMock);

            _brokerRepositoryMock = new Mock<IBrokerRepository>();

            // Initialize the mocked repository
            _brokerRepositoryMock.Setup(repository => repository.GetAll())
                .ReturnsAsync(_brokerListMock);
            _brokerRepositoryMock.Setup(repository => repository.Get(1))
                .ReturnsAsync(_brokerListMock.ElementAt(0));
            _brokerRepositoryMock.Setup(repository => repository.Get(9))
                .ReturnsAsync(null);

            // Use the mock to create an instance of the service
            _brokerServiceMock = new BrokerService(_brokerRepositoryMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldNotReturnNull()
        {
            var result = await _brokerServiceMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerEntitiesType()
        {
            var result = await _brokerServiceMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, _brokerListDtoMock.GetType());
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerDTOEntities()
        {
            var result = await _brokerServiceMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, _brokerListDtoMock.Count);
            Assert.IsTrue(CompareBrokerDTO(result.ElementAt(0), _brokerListDtoMock.ElementAt(0)));
            Assert.IsTrue(CompareBrokerDTO(result.ElementAt(1), _brokerListDtoMock.ElementAt(1)));
            Assert.IsTrue(CompareBrokerDTO(result.ElementAt(2), _brokerListDtoMock.ElementAt(2)));
            Assert.IsTrue(CompareBrokerDTO(result.ElementAt(3), _brokerListDtoMock.ElementAt(3)));
            Assert.IsTrue(CompareBrokerDTO(result.ElementAt(4), _brokerListDtoMock.ElementAt(4)));
        }

        [Test]
        public async Task Get_ShouldReturnNullIfBrokerDoesNotExists()
        {
            var result = await _brokerServiceMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task Get_ShouldReturnBrokerDTOIfBrokerExists()
        {
            var result = await _brokerServiceMock.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(CompareBrokerDTO(result, _brokerListDtoMock.ElementAt(0)));
        }

        /// <summary>
        /// Method that compares the values from the properties to check if they are the same
        /// </summary>
        /// <param name="broker1">Broker entity</param>
        /// <param name="broker2">Broker entity</param>
        /// <returns>True if the values are the same, false otherwise</returns>
        private bool CompareBrokerDTO(BrokerDTO broker1, BrokerDTO broker2)
        {
            return broker1.Id == broker2.Id
                   && broker1.Email == broker2.Email
                   && broker1.ImageUrl == broker2.ImageUrl
                   && broker1.MobilePhoneNumber == broker2.MobilePhoneNumber
                   && broker1.Name == broker2.Name
                   && broker1.OfficePhoneNumber == broker2.OfficePhoneNumber
                   && broker1.Position == broker2.Position;
        }
    }
}
