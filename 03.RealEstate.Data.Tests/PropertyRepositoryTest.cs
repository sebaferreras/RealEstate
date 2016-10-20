using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using _03.RealEstate.Data.Context;
using _03.RealEstate.Data.Repositories;
using _03.RealEstate.Data.Tests.Helpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _03.RealEstate.Data.Tests
{
    [TestFixture]
    public class PropertyRepositoryTest
    {
        private Mock<IRealStateContext> _realStateContextMock;
        private Mock<DbSet<Property>> _propertyDbSetMock;
        private IPropertyRepository _propertyRepositoryMock;

        #region PropertyListMock
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
                PreviewImageUrl = "www.placehold.it/350x350",
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
                PreviewImageUrl = "www.placehold.it/350x350",
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
                PreviewImageUrl = "www.placehold.it/350x350",
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
            var data = _propertyListMock.AsQueryable();

            // First we mock the DbSet
            _propertyDbSetMock = new Mock<DbSet<Property>>();

            // Since we're faking the db context with async methods, we need to set up a few things
            _propertyDbSetMock.As<IDbAsyncEnumerable<Property>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Property>(data.GetEnumerator()));

            _propertyDbSetMock.As<IQueryable<Property>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Property>(data.Provider));

            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.Expression).Returns(data.Expression);
            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Now we can mock the entire context
            _realStateContextMock = new Mock<IRealStateContext>();
            _realStateContextMock.Setup(context => context.Properties).Returns(_propertyDbSetMock.Object);

            // Initialize the repository with the mocked dbContext
            _propertyRepositoryMock = new PropertyRepository(_realStateContextMock.Object);
        }

        [Test]
        public async Task GetAllMethodShouldNotReturnNull()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfPropertyEntitiesType()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, _propertyListMock.GetType());
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfPropertyEntities()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, _propertyListMock.Count);
            Assert.AreEqual(result.ElementAt(0), _propertyListMock.ElementAt(0));
            Assert.AreEqual(result.ElementAt(1), _propertyListMock.ElementAt(1));
            Assert.AreEqual(result.ElementAt(2), _propertyListMock.ElementAt(2));
        }

        [Test]
        public async Task GetMethodShouldReturnNullIfPropertyDoesNotExists()
        {
            var result = await _propertyRepositoryMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMethodShouldReturnPropertyIfPropertyExists()
        {
            var result = await _propertyRepositoryMock.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, _propertyListMock.ElementAt(0));
        }

        [Test]
        public void AddMethodShouldThrowNotImplementedException()
        {
            try
            {
                _propertyRepositoryMock.Add(_propertyListMock.ElementAt(0));
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }

        [Test]
        public void UpdateMethodShouldThrowNotImplementedException()
        {
            try
            {
                _propertyRepositoryMock.Update(_propertyListMock.ElementAt(0));
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }

        [Test]
        public void DeleteMethodShouldThrowNotImplementedException()
        {
            try
            {
                _propertyRepositoryMock.Delete(_propertyListMock.ElementAt(0).Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }
    }
}
