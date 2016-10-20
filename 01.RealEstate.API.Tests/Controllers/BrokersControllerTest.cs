using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoMapper;
using Moq;
using NUnit.Framework;
using _01.RealEstate.API.Controllers;
using _02.RealEstate.Domain.Automapper;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.Entities.Mocks;
using _02.RealEstate.Domain.IServices;
using _02.RealEstate.Domain.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _01.RealEstate.API.Tests.Controllers
{
    [TestFixture]
    public class BrokersControllerTest
    {
        // Mocks
        private Mock<IBrokerService> _brokerServiceMock;
        private BrokersController _brokerControllerMock;
        private List<BrokerDTO> _brokerDTOListMock;

        [SetUp]
        public void Initialize()
        {
            // Since the repository returns Broker entities but the service returns BrokerDTO entities we need to initialize Automapper
            AutomapperBootstrapper.Initialize();

            // Initialize the data we're going to use in the tests
            _brokerDTOListMock = Mapper.Map<List<Broker>, List<BrokerDTO>>(BrokerMocks.GetBrokerListMock());

            _brokerServiceMock = new Mock<IBrokerService>();

            // Initialize the mocked service
            _brokerServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(_brokerDTOListMock);
            _brokerServiceMock.Setup(service => service.Get(1))
                .ReturnsAsync(_brokerDTOListMock.ElementAt(0));
            _brokerServiceMock.Setup(service => service.Get(9))
                .ReturnsAsync(null);

            // Use the mock to create an instance of the service
            _brokerControllerMock = new BrokersController(_brokerServiceMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldNotReturnNull()
        {
            var result = await _brokerControllerMock.Get() as OkNegotiatedContentResult<List<BrokerDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerDTOEntityType()
        {
            var result = await _brokerControllerMock.Get() as OkNegotiatedContentResult<List<BrokerDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsInstanceOfType(result.Content, _brokerDTOListMock.GetType());
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerDTOEntities()
        {
            var result = await _brokerControllerMock.Get() as OkNegotiatedContentResult<List<BrokerDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Count, _brokerDTOListMock.Count);
            Assert.IsTrue(CompareBrokerDTO(result.Content.ElementAt(0), _brokerDTOListMock.ElementAt(0)));
            Assert.IsTrue(CompareBrokerDTO(result.Content.ElementAt(1), _brokerDTOListMock.ElementAt(1)));
            Assert.IsTrue(CompareBrokerDTO(result.Content.ElementAt(2), _brokerDTOListMock.ElementAt(2)));
            Assert.IsTrue(CompareBrokerDTO(result.Content.ElementAt(3), _brokerDTOListMock.ElementAt(3)));
            Assert.IsTrue(CompareBrokerDTO(result.Content.ElementAt(4), _brokerDTOListMock.ElementAt(4)));
        }

        [Test]
        public async Task Get_ShouldReturnNotFoundIfBrokerDoesNotExists()
        {
            var result = await _brokerControllerMock.Get(9);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [Test]
        public async Task Get_ShouldReturnBrokerDTOIfBrokerExists()
        {
            var result = await _brokerControllerMock.Get(1) as OkNegotiatedContentResult<BrokerDTO>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(CompareBrokerDTO(result.Content, _brokerDTOListMock.ElementAt(0)));
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
