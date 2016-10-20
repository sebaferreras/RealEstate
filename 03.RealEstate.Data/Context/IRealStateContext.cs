using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.RealEstate.Domain.Entities;

namespace _03.RealEstate.Data.Context
{
    public interface IRealStateContext : IDisposable
    {
        DbSet<Broker> Brokers { get; }
        DbSet<Property> Properties { get; }
    }
}
