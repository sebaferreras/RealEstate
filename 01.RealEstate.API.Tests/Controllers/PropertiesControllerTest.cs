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
    public class PropertiesControllerTest
    {
        // Mocks
        private Mock<IPropertyService> _propertyServiceMock;
        private PropertiesController _propertiesControllerMock;
        private List<PropertyListItemDTO> _propertyListItemDTOMock;
        private PropertyDTO _propertyDtoMock;

        [SetUp]
        public void Initialize()
        {
            // Since the repository returns Broker entities but the service returns BrokerDTO entities we need to initialize Automapper
            AutomapperBootstrapper.Initialize();

            // Initialize the data we're going to use in the tests
            _propertyListItemDTOMock =
                Mapper.Map<List<Property>, List<PropertyListItemDTO>>(PropertyMocks.GetPropertyListMock());
            _propertyDtoMock = Mapper.Map<Property, PropertyDTO>(PropertyMocks.GetPropertyListMock().ElementAt(0));

            _propertyServiceMock = new Mock<IPropertyService>();

            // Initialize the mocked service
            _propertyServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(_propertyListItemDTOMock);
            _propertyServiceMock.Setup(service => service.Get(1))
                .ReturnsAsync(_propertyDtoMock);
            _propertyServiceMock.Setup(service => service.Get(9))
                .ReturnsAsync(null);

            // Use the mock to create an instance of the service
            _propertiesControllerMock = new PropertiesController(_propertyServiceMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldNotReturnNull()
        {
            var result = await _propertiesControllerMock.Get() as OkNegotiatedContentResult<List<PropertyListItemDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfPropertyEntityType()
        {
            var result = await _propertiesControllerMock.Get() as OkNegotiatedContentResult<List<PropertyListItemDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsInstanceOfType(result.Content, _propertyListItemDTOMock.GetType());
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfPropertyListItemDTOEntities()
        {
            var result = await _propertiesControllerMock.Get() as OkNegotiatedContentResult<List<PropertyListItemDTO>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Count, _propertyListItemDTOMock.Count);
            Assert.IsTrue(ComparePropertyListItemDTO(result.Content.ElementAt(0), _propertyListItemDTOMock.ElementAt(0)));
            Assert.IsTrue(ComparePropertyListItemDTO(result.Content.ElementAt(1), _propertyListItemDTOMock.ElementAt(1)));
            Assert.IsTrue(ComparePropertyListItemDTO(result.Content.ElementAt(2), _propertyListItemDTOMock.ElementAt(2)));
        }

        [Test]
        public async Task Get_ShouldReturnNotFoundIfPropertyDoesNotExists()
        {
            var result = await _propertiesControllerMock.Get(9);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [Test]
        public async Task Get_ShouldReturnPropertyDTOIfPropertyExists()
        {
            var result = await _propertiesControllerMock.Get(1) as OkNegotiatedContentResult<PropertyDTO>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(ComparePropertyDTO(result.Content, _propertyDtoMock));
        }

        /// <summary>
        /// Method that compares if two instances of PropertyDTO are the same
        /// </summary>
        /// <param name="property1">PropertyDTO entity</param>
        /// <param name="property2">PropertyDTO entity</param>
        /// <returns>True if the values are the same, false otherwise</returns>
        private bool ComparePropertyDTO(PropertyDTO property1, PropertyDTO property2)
        {
            return property1.Id == property2.Id
                   && property1.AskingPrice == property2.AskingPrice
                   && property1.Bathrooms == property2.Bathrooms
                   && property1.Bedrooms == property2.Bedrooms
                   && property1.BrokerId == property2.BrokerId
                   && property1.BrokerImageUrl == property2.BrokerImageUrl
                   && property1.BrokerName == property2.BrokerName
                   && property1.BrokerPosition == property2.BrokerPosition
                   && property1.Description == property2.Description
                   && property1.ImageUrl == property2.ImageUrl
                   && property1.Location == property2.Location
                   && property1.PreviewImageUrl == property2.PreviewImageUrl
                   && property1.Title == property2.Title;

        }

        /// <summary>
        /// Method that compares if two instances of PropertyListItemDTO are the same
        /// </summary>
        /// <param name="property1">PropertyListItemDTO entity</param>
        /// <param name="property2">PropertyListItemDTO entity</param>
        /// <returns>True if the values are the same, false otherwise</returns>
        private bool ComparePropertyListItemDTO(PropertyListItemDTO property1, PropertyListItemDTO property2)
        {
            return property1.Id == property2.Id
                   && property1.ImageUrl == property2.ImageUrl
                   && property1.Location == property2.Location
                   && property1.PreviewImageUrl == property2.PreviewImageUrl
                   && property1.Title == property2.Title;
        }

    }
}
