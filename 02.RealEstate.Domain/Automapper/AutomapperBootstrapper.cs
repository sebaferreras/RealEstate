using AutoMapper;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.Entities;

namespace _02.RealEstate.Domain.Automapper
{
    public class AutomapperBootstrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                // Mappings
                cfg.CreateMap<Property, PropertyListItemDTO>();
                cfg.CreateMap<Property, PropertyDTO>().ReverseMap();

                cfg.CreateMap<Broker, BrokerDTO>().ReverseMap();
            });
        }
    }
}
