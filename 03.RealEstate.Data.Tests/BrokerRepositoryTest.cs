using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IRepositories;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _03.RealEstate.Data.Tests
{
    [TestFixture]
    public class BrokerRepositoryTest
    {

        private Mock<IBrokerRepository> _brokerRepositoryMock;

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
            _brokerRepositoryMock = new Mock<IBrokerRepository>();

            // Initialize the mocked service
            _brokerRepositoryMock.Setup(reposritory => reposritory.GetAll())
                .ReturnsAsync(brokerListMock);
            _brokerRepositoryMock.Setup(reposritory => reposritory.Get(1))
                .ReturnsAsync(brokerListMock.ElementAt(0));
            _brokerRepositoryMock.Setup(reposritory => reposritory.Get(9))
                .ReturnsAsync(null);
            _brokerRepositoryMock.Setup(repository => repository.Add(brokerListMock.ElementAt(0)))
                .Throws(new NotImplementedException());
            _brokerRepositoryMock.Setup(repository => repository.Update(brokerListMock.ElementAt(0)))
                .Throws(new NotImplementedException());
            _brokerRepositoryMock.Setup(repository => repository.Delete(brokerListMock.ElementAt(0).Id))
                .Throws(new NotImplementedException());
        }

        [Test]
        public void GetAllMethodShouldNotReturnNull()
        {
            var result = _brokerRepositoryMock.Object.GetAll().Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllMethodShouldReturnList()
        {
            var result = _brokerRepositoryMock.Object.GetAll().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, brokerListMock.Count);
        }

        [Test]
        public void GetMethodShouldReturnNullIfBrokerDoesNotExists()
        {
            var result = _brokerRepositoryMock.Object.Get(9).Result;
            Assert.IsNull(result);
        }

        [Test]
        public void GetMethodShouldReturnBrokerIfBrokerExists()
        {
            var result = _brokerRepositoryMock.Object.Get(1).Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddMethodShouldThrowNotImplementedException()
        {
            try
            {
                _brokerRepositoryMock.Object.Add(brokerListMock.ElementAt(0));
            }
            catch (Exception ex)
            {   
                Assert.AreEqual(ex.GetType(),  typeof(NotImplementedException));
            }
        }

        [Test]
        public void UpdateMethodShouldThrowNotImplementedException()
        {
            try
            {
                _brokerRepositoryMock.Object.Update(brokerListMock.ElementAt(0));
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
                _brokerRepositoryMock.Object.Delete(brokerListMock.ElementAt(0).Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }
    }
}
