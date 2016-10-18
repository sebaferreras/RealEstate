using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;

namespace _03.RealEstate.Data.Context
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(): base("name=DefaultConnection")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Broker> Brokers { get; set; }
    }
}
