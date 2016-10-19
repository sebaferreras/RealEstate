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
    public class PropertyRepositoryTest
    {

        private Mock<IPropertyRepository> _propertyRepositoryMock;

        #region PropertyListMock
        private List<Property> propertyListMock = new List<Property>
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
            _propertyRepositoryMock = new Mock<IPropertyRepository>();

            // Initialize the mocked service
            _propertyRepositoryMock.Setup(reposritory => reposritory.GetAll())
                .ReturnsAsync(propertyListMock);
            _propertyRepositoryMock.Setup(reposritory => reposritory.Get(1))
                .ReturnsAsync(propertyListMock.ElementAt(0));
            _propertyRepositoryMock.Setup(reposritory => reposritory.Get(9))
                .ReturnsAsync(null);
            _propertyRepositoryMock.Setup(repository => repository.Add(propertyListMock.ElementAt(0)))
                .Throws(new NotImplementedException());
            _propertyRepositoryMock.Setup(repository => repository.Update(propertyListMock.ElementAt(0)))
                .Throws(new NotImplementedException());
            _propertyRepositoryMock.Setup(repository => repository.Delete(propertyListMock.ElementAt(0).Id))
                .Throws(new NotImplementedException());
        }

        [Test]
        public void GetAllMethodShouldNotReturnNull()
        {
            var result = _propertyRepositoryMock.Object.GetAll().Result;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllMethodShouldReturnList()
        {
            var result = _propertyRepositoryMock.Object.GetAll().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, propertyListMock.Count);
        }

        [Test]
        public void GetMethodShouldReturnNullIfPropertyDoesNotExists()
        {
            var result = _propertyRepositoryMock.Object.Get(9).Result;
            Assert.IsNull(result);
        }

        [Test]
        public void GetMethodShouldReturnPropertyIfPropertyExists()
        {
            var result = _propertyRepositoryMock.Object.Get(1).Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddMethodShouldThrowNotImplementedException()
        {
            try
            {
                _propertyRepositoryMock.Object.Add(propertyListMock.ElementAt(0));
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
                _propertyRepositoryMock.Object.Update(propertyListMock.ElementAt(0));
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
                _propertyRepositoryMock.Object.Delete(propertyListMock.ElementAt(0).Id);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(NotImplementedException));
            }
        }
    }
}
