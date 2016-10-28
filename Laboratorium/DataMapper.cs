using Laboratorium.Models.ViewModels;
using AutoMapper;
using Laboratorium.Core;

namespace Laboratorium
{
    public class DataMapper
    {
        public DataMapper()
        {
            CreatePacketMap();
        }

        private void CreatePacketMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Packet, PacketViewModel>();
                cfg.CreateMap<PacketViewModel, Packet>();
            });
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}