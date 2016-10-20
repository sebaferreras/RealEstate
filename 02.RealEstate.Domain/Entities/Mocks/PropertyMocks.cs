using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RealEstate.Domain.Entities.Mocks
{
    public static class PropertyMocks
    {
        public static List<Property> GetPropertyListMock()
        {
            return new List<Property>
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
        }
    }
}
