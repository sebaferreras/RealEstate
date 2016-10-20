using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RealEstate.Domain.Entities.Mocks
{
    public static class BrokerMocks
    {
        public static List<Broker> GetBrokerListMock()
        {
            return new List<Broker>
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
        }
    }
}
