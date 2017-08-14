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
            CreateMap();
            //CreatePacketMap();
            //CreateUserMap();
        }

        private void CreateMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Packet, PacketViewModel>();
                cfg.CreateMap<PacketViewModel, Packet>();

                cfg.CreateMap<AspNetUser, AccountsListItem>();
                cfg.CreateMap<AspNetUser, SetAccountPassword>();
            });
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
                cfg.CreateMap<AspNetUser, SetAccountPassword>();
            });
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}