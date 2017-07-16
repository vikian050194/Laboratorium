using AutoMapper;
using Laboratorium.Core.Containers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Helpers
{
    public class DataMapper
    {
        public DataMapper()
        {
            CreatePacketMap();
            CreateUserMap();
        }

        private void CreatePacketMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Packet, PacketViewModel>();
                cfg.CreateMap<PacketViewModel, Packet>();
            });
        }

        private void CreateUserMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AspNetUser, AccountsListItem>();
            });
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}