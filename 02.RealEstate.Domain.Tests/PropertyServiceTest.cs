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
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;
using _02.RealEstate.Domain.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _02.RealEstate.Domain.Tests
{
    [TestFixture]
    public class PropertyServiceTest
    {
        private Mock<IPropertyRepository> _propertyRepositoryMock;
        private IPropertyService _propertyServiceMock;

        private List<PropertyListItemDTO> _propertyListItemDtoMock;
        private PropertyDTO _propertyDtoMock;

        #region _propertyListMock
        private readonly List<Property> _propertyListMock = new List<Property>
        {
            new Property
            {
                Id = 1,
                Title = "Property Title",
                Location = "Property Location",
                Bathrooms = 1,
                Bedrooms = 2,
                AskingPrice = 150000,
                ImageUrl = "www.placehold.it/350x350",
                PreviewImageUrl = "www.placehold.it/150x150",
                Description = "Property Description",
                BrokerId = 1,
                Broker = new Broker
                        {
                            Id = 1,
                            Name = "Broker Name",
                            Position = "Broker Position",
                            Email = "email@domain.com",
                            ImageUrl = "www.placehold.it/350x350",
                            MobilePhoneNumber = "618 437410",
                            OfficePhoneNumber = "621 123951"
                        }
            },
            new Property
            {
                Id = 2,
                Title = "Property Title",
                Location = "Property Location",
                Bathrooms = 1,
                Bedrooms = 2,
                AskingPrice = 150000,
                ImageUrl = "www.placehold.it/350x350",
                PreviewImageUrl = "www.placehold.it/150x150",
                Description = "Property Description",
                BrokerId = 2,
                Broker = new Broker
                        {
                            Id = 2,
                            Name = "Broker Name",
                            Position = "Broker Position",
                            Email = "email@domain.com",
                            ImageUrl = "www.placehold.it/350x350",
                            MobilePhoneNumber = "618 437410",
                            OfficePhoneNumber = "621 123951"
                        }
            },
            new Property
            {
                Id = 3,
                Title = "Property Title",
                Location = "Property Location",
                Bathrooms = 1,
                Bedrooms = 2,
                AskingPrice = 150000,
                ImageUrl = "www.placehold.it/350x350",
                PreviewImageUrl = "www.placehold.it/150x150",
                Description = "Property Description",
                BrokerId = 3,
                Broker = new Broker
                        {
                            Id = 3,
                            Name = "Broker Name",
                            Position = "Broker Position",
                            Email = "email@domain.com",
                            ImageUrl = "www.placehold.it/350x350",
                            MobilePhoneNumber = "618 437410",
                            OfficePhoneNumber = "621 123951"
                        }
            }

        };
        #endregion

        [SetUp]
        public void Initialize()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();

            // Initialize the mocked repository
            _propertyRepositoryMock.Setup(repository => repository.GetAll())
                .ReturnsAsync(_propertyListMock);
            _propertyRepositoryMock.Setup(repository => repository.Get(1))
                .ReturnsAsync(_propertyListMock.ElementAt(0));
            _propertyRepositoryMock.Setup(repository => repository.Get(9))
                .ReturnsAsync(null);

            // Since the repository returns Property entities but the service returns DTO entities
            // we need to initialize Automapper
            AutomapperBootstrapper.Initialize();

            // Get the DTO's by using the moked list
            _propertyListItemDtoMock = Mapper.Map<List<Property>, List<PropertyListItemDTO>>(_propertyListMock);
            _propertyDtoMock = Mapper.Map<Property, PropertyDTO>(_propertyListMock.ElementAt(0));

            // Use the mock to create an instance of the service
            _propertyServiceMock = new PropertyService(_propertyRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllMethodShouldNotReturnNull()
        {
            var result = await _propertyServiceMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfPropertyListItemDTOType()
        {
            var result = await _propertyServiceMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, _propertyListItemDtoMock.GetType());
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfPropertyListItemDTOEntities()
        {
            var result = await _propertyServiceMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, _propertyListItemDtoMock.Count);
            Assert.IsTrue(ComparePropertyListItemDTO(result.ElementAt(0), _propertyListItemDtoMock.ElementAt(0)));
            Assert.IsTrue(ComparePropertyListItemDTO(result.ElementAt(1), _propertyListItemDtoMock.ElementAt(1)));
            Assert.IsTrue(ComparePropertyListItemDTO(result.ElementAt(2), _propertyListItemDtoMock.ElementAt(2)));
        }

        [Test]
        public async Task GetMethodShouldReturnNullIfPropertyDoesNotExists()
        {
            var result = await _propertyServiceMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMethodShouldReturnPropertyDTOIfPropertyExists()
        {
            var result = await _propertyServiceMock.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(ComparePropertyDTO(result, _propertyDtoMock));
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
