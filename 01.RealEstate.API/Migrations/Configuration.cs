using _02.RealEstate.Domain.Entities;

namespace _01.RealEstate.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_03.RealEstate.Data.Context.RealEstateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_03.RealEstate.Data.Context.RealEstateContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Adds borkers to the db
            context.Brokers.AddOrUpdate(
                new Broker
                {
                    Name = "Leslie Anderson",
                    Email = "lesliea@realestate.com",
                    ImageUrl = "https://randomuser.me/api/portraits/women/72.jpg",
                    Position = "Senior Broker",
                    OfficePhoneNumber = "618 712 1238",
                    MobilePhoneNumber = "621 951 2371"
                },
                new Broker
                {
                    Name = "Leo Williams",
                    Email = "leow@realestate.com",
                    ImageUrl = "https://randomuser.me/api/portraits/men/82.jpg",
                    Position = "Senior Broker",
                    OfficePhoneNumber = "618 712 2341",
                    MobilePhoneNumber = "621 951 7529"
                },
                new Broker
                {
                    Name = "Kathy Woods",
                    Email = "kathyw@realestate.com",
                    ImageUrl = "https://randomuser.me/api/portraits/women/93.jpg",
                    Position = "Senior Broker",
                    OfficePhoneNumber = "618 456 4127",
                    MobilePhoneNumber = "621 951 6512"
                },
                new Broker
                {
                    Name = "Logan Jennings",
                    Email = "loganj@realestate.com",
                    ImageUrl = "https://randomuser.me/api/portraits/men/21.jpg",
                    Position = "Senior Broker",
                    OfficePhoneNumber = "618 756 3413",
                    MobilePhoneNumber = "621 243 1236"
                }
            );

            context.Properties.AddOrUpdate(
                new Property
                {
                    Title = "Condominium Redefined",
                    Location = "Boston, MA",
                    Description = "",
                    ImageUrl = "https://images.unsplash.com/photo-1473784668541-b9e6d44b720c?dpr=1.75&auto=compress,format&crop=entropy&fit=crop&w=376&h=251&q=80&cs=tinysrgb",
                    Bedrooms = 1,
                    Bathrooms = 2,
                    BrokerId = 1014,
                    AskingPrice = 525000
                },
                new Property
                {
                    Title = "Quiet Retreat",
                    Location = "Cambridge, MA",
                    Description = "",
                    ImageUrl = "https://images.unsplash.com/photo-1472224371017-08207f84aaae?dpr=1.75&auto=compress,format&crop=entropy&fit=crop&w=376&h=251&q=80&cs=tinysrgb",
                    Bedrooms = 1,
                    Bathrooms = 2,
                    BrokerId = 1015,
                    AskingPrice = 890000
                },
                new Property
                {
                    Title = "Suburban Luxury",
                    Location = "Boston, MA",
                    Description = "",
                    ImageUrl = "https://images.unsplash.com/photo-1416331108676-a22ccb276e35?dpr=1.75&auto=compress,format&crop=entropy&fit=crop&w=376&h=252&q=80&cs=tinysrgb",
                    Bedrooms = 5,
                    Bathrooms = 4,
                    BrokerId = 1015,
                    AskingPrice = 2300000
                },
                new Property
                {
                    Title = "Modern Elegance",
                    Location = "Cambridge, MA",
                    Description = "",
                    ImageUrl = "https://images.unsplash.com/photo-1430285561322-7808604715df?dpr=1.75&auto=compress,format&crop=entropy&fit=crop&w=376&h=251&q=80&cs=tinysrgb",
                    Bedrooms = 3,
                    Bathrooms = 2,
                    BrokerId = 1016,
                    AskingPrice = 375000
                },
                new Property
                {
                    Title = "Victorian Retreat",
                    Location = "Cambridge, MA",
                    Description = "",
                    ImageUrl = "https://images.unsplash.com/photo-1475665724515-6d075e9759f7?dpr=1.75&auto=compress,format&crop=entropy&fit=crop&w=376&h=251&q=80&cs=tinysrgb",
                    Bedrooms = 1,
                    Bathrooms = 3,
                    BrokerId = 1017,
                    AskingPrice = 475000
                }
            );
        }
    }
}
