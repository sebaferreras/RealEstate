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
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using _03.RealEstate.Data.Context;
using _03.RealEstate.Data.Repositories;
using _03.RealEstate.Data.Tests.Helpers;
using _02.RealEstate.Domain.Entities.Mocks;

namespace _03.RealEstate.Data.Tests.Repositories
{
    [TestFixture]
    public class BrokerRepositoryTest
    {
        // Mocks
        private Mock<IRealStateContext> _realStateContextMock;
        private Mock<DbSet<Broker>> _brokerDbSetMock;
        private IBrokerRepository _brokerRepositoryMock;
        private List<Broker> _brokerListMock;

        [SetUp]
        public void Initialize()
        {
            // Initialize the data we're going to use in the tests
            _brokerListMock = BrokerMocks.GetBrokerListMock();

            // First we need to mock the DbSet
            _brokerDbSetMock = new Mock<DbSet<Broker>>();

            // Since we're faking the db context with async methods, we need to set up a few things first
            _brokerDbSetMock.As<IDbAsyncEnumerable<Broker>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Broker>(_brokerListMock.AsQueryable().GetEnumerator()));

            _brokerDbSetMock.As<IQueryable<Broker>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Broker>(_brokerListMock.AsQueryable().Provider));

            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.Expression).Returns(_brokerListMock.AsQueryable().Expression);
            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.ElementType).Returns(_brokerListMock.AsQueryable().ElementType);
            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.GetEnumerator()).Returns(_brokerListMock.AsQueryable().GetEnumerator());

            // Now we can mock the entire context
            _realStateContextMock = new Mock<IRealStateContext>();
            _realStateContextMock.Setup(context => context.Brokers).Returns(_brokerDbSetMock.Object);

            // Initialize the repository with the mocked dbContext
            _brokerRepositoryMock = new BrokerRepository(_realStateContextMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldNotReturnNull()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerEntitiesType()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, _brokerListMock.GetType());
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfBrokerEntities()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, _brokerListMock.Count);
            Assert.AreEqual(result.ElementAt(0), _brokerListMock.ElementAt(0));
            Assert.AreEqual(result.ElementAt(1), _brokerListMock.ElementAt(1));
            Assert.AreEqual(result.ElementAt(2), _brokerListMock.ElementAt(2));
            Assert.AreEqual(result.ElementAt(3), _brokerListMock.ElementAt(3));
            Assert.AreEqual(result.ElementAt(4), _brokerListMock.ElementAt(4));
        }

        [Test]
        public async Task Get_ShouldReturnNullIfBrokerDoesNotExists()
        {
            var result = await _brokerRepositoryMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task Get_ShouldReturnBrokerIfBrokerExists()
        {
            var result = await _brokerRepositoryMock.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, _brokerListMock.ElementAt(0));
        }

        [Test]
        public void Add_ShouldThrowNotImplementedException()
        {
            try
            {
                _brokerRepositoryMock.Add(_brokerListMock.ElementAt(0));
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
                _brokerRepositoryMock.Update(_brokerListMock.ElementAt(0));
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
                _brokerRepositoryMock.Delete(_brokerListMock.ElementAt(0).Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }
    }
}
