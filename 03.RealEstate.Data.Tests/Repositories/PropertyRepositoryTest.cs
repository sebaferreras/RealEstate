using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.Entities.Mocks;
using _02.RealEstate.Domain.IRepositories;
using _03.RealEstate.Data.Context;
using _03.RealEstate.Data.Repositories;
using _03.RealEstate.Data.Tests.Helpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _03.RealEstate.Data.Tests.Repositories
{
    [TestFixture]
    public class PropertyRepositoryTest
    {
        // Mocks
        private Mock<IRealStateContext> _realStateContextMock;
        private Mock<DbSet<Property>> _propertyDbSetMock;
        private IPropertyRepository _propertyRepositoryMock;
        private List<Property> _propertyListMock;

        [SetUp]
        public void Initialize()
        {
            // Initialize the data we're going to use in the tests
            _propertyListMock = PropertyMocks.GetPropertyListMock();

            // First we neet to mock the DbSet
            _propertyDbSetMock = new Mock<DbSet<Property>>();

            // Since we're faking the db context with async methods, we need to set up a few things
            _propertyDbSetMock.As<IDbAsyncEnumerable<Property>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Property>(_propertyListMock.AsQueryable().GetEnumerator()));

            _propertyDbSetMock.As<IQueryable<Property>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Property>(_propertyListMock.AsQueryable().Provider));

            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.Expression).Returns(_propertyListMock.AsQueryable().Expression);
            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.ElementType).Returns(_propertyListMock.AsQueryable().ElementType);
            _propertyDbSetMock.As<IQueryable<Property>>().Setup(m => m.GetEnumerator()).Returns(_propertyListMock.AsQueryable().GetEnumerator());

            // Now we can mock the entire context
            _realStateContextMock = new Mock<IRealStateContext>();
            _realStateContextMock.Setup(context => context.Properties).Returns(_propertyDbSetMock.Object);

            // Initialize the repository with the mocked dbContext
            _propertyRepositoryMock = new PropertyRepository(_realStateContextMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldNotReturnNull()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfPropertyEntitiesType()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, _propertyListMock.GetType());
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfPropertyEntities()
        {
            var result = await _propertyRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, _propertyListMock.Count);
            Assert.AreEqual(result.ElementAt(0), _propertyListMock.ElementAt(0));
            Assert.AreEqual(result.ElementAt(1), _propertyListMock.ElementAt(1));
            Assert.AreEqual(result.ElementAt(2), _propertyListMock.ElementAt(2));
        }

        [Test]
        public async Task Get_ShouldReturnNullIfPropertyDoesNotExists()
        {
            var result = await _propertyRepositoryMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task Get_ShouldReturnPropertyIfPropertyExists()
        {
            var result = await _propertyRepositoryMock.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, _propertyListMock.ElementAt(0));
        }

        [Test]
        public void Add_ShouldThrowNotImplementedException()
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
        public void Update_ShouldThrowNotImplementedException()
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
        public void Delete_ShouldThrowNotImplementedException()
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
