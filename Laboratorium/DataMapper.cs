using Laboratorium.Models.ViewModels;
using LaboratoriumCore;
using AutoMapper;

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
            Mapper.Initialize(cfg => cfg.CreateMap<Packet, PacketViewModel>());
            .CreateMap<Packet, PacketViewModel>();
            Mapper.CreateMap<PacketViewModel, Packet>();
        }

        public TDestination GetWrapper<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}