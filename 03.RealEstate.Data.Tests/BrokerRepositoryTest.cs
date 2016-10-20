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

namespace _03.RealEstate.Data.Tests
{
    [TestFixture]
    public class BrokerRepositoryTest
    {
        private Mock<IRealStateContext> _realStateContextMock;
        private Mock<DbSet<Broker>> _brokerDbSetMock;
        private IBrokerRepository _brokerRepositoryMock;

        #region BrokerListMock
        private List<Broker> brokerListMock = new List<Broker>
        {
            new Broker
            {
                Id = 1,
                Name = "Broker Name",
                Position = "Broker Position",
                Email = "email@domain.com",
                ImageUrl = "www.placehold.it/350x350",
                MobilePhoneNumber = "618 437410",
                OfficePhoneNumber = "621 123951"
            },
            new Broker
            {
                Id = 2,
                Name = "Broker Name",
                Position = "Broker Position",
                Email = "email@domain.com",
                ImageUrl = "www.placehold.it/350x350",
                MobilePhoneNumber = "618 437410",
                OfficePhoneNumber = "621 123951"
            },
            new Broker
            {
                Id = 3,
                Name = "Broker Name",
                Position = "Broker Position",
                Email = "email@domain.com",
                ImageUrl = "www.placehold.it/350x350",
                MobilePhoneNumber = "618 437410",
                OfficePhoneNumber = "621 123951"
            },
            new Broker
            {
                Id = 4,
                Name = "Broker Name",
                Position = "Broker Position",
                Email = "email@domain.com",
                ImageUrl = "www.placehold.it/350x350",
                MobilePhoneNumber = "618 437410",
                OfficePhoneNumber = "621 123951"
            },
            new Broker
            {
                Id = 5,
                Name = "Broker Name",
                Position = "Broker Position",
                Email = "email@domain.com",
                ImageUrl = "www.placehold.it/350x350",
                MobilePhoneNumber = "618 437410",
                OfficePhoneNumber = "621 123951"
            }
        };
        #endregion

        [SetUp]
        public void Initialize()
        {
            var data = brokerListMock.AsQueryable();

            // First we need to mock the DbSet
            _brokerDbSetMock = new Mock<DbSet<Broker>>();

            // Since we're faking the db context with async methods, we need to set up a few things
            _brokerDbSetMock.As<IDbAsyncEnumerable<Broker>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Broker>(data.GetEnumerator()));

            _brokerDbSetMock.As<IQueryable<Broker>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Broker>(data.Provider));

            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.Expression).Returns(data.Expression);
            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _brokerDbSetMock.As<IQueryable<Broker>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Now we can mock the entire context
            _realStateContextMock = new Mock<IRealStateContext>();
            _realStateContextMock.Setup(context => context.Brokers).Returns(_brokerDbSetMock.Object);

            // Initialize the repository with the mocked dbContext
            _brokerRepositoryMock = new BrokerRepository(_realStateContextMock.Object);
        }

        [Test]
        public async Task GetAllMethodShouldNotReturnNull()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfBrokerEntitiesType()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, brokerListMock.GetType());
        }

        [Test]
        public async Task GetAllMethodShouldReturnListOfBrokerEntities()
        {
            var result = await _brokerRepositoryMock.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, brokerListMock.Count);
            Assert.AreEqual(result.ElementAt(0), brokerListMock.ElementAt(0));
            Assert.AreEqual(result.ElementAt(1), brokerListMock.ElementAt(1));
            Assert.AreEqual(result.ElementAt(2), brokerListMock.ElementAt(2));
            Assert.AreEqual(result.ElementAt(3), brokerListMock.ElementAt(3));
            Assert.AreEqual(result.ElementAt(4), brokerListMock.ElementAt(4));
        }

        [Test]
        public async Task GetMethodShouldReturnNullIfBrokerDoesNotExists()
        {
            var result = await _brokerRepositoryMock.Get(9);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMethodShouldReturnBrokerIfBrokerExists()
        {
            var result = await _brokerRepositoryMock.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brokerListMock.ElementAt(0));
        }

        [Test]
        public void AddMethodShouldThrowNotImplementedException()
        {
            try
            {
                _brokerRepositoryMock.Add(brokerListMock.ElementAt(0));
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
                _brokerRepositoryMock.Update(brokerListMock.ElementAt(0));
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
                _brokerRepositoryMock.Delete(brokerListMock.ElementAt(0).Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }
    }
}
