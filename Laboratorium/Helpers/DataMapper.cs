using System;
using System.Linq;
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

        private string GetRoleName(string id)
        {
            switch (id)
            {
                case "Admin":
                    return @"Администратор";
                case "User":
                    return @"Пользователь";
                default:
                    return "Ошибка!";
            }
        }

        private void CreateMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Packet, PacketViewModel>();

                cfg.CreateMap<PacketViewModel, PacketEntity>();
                cfg.CreateMap<PacketViewModel, Packet>();

                cfg.CreateMap<PacketEntity, PacketEntity>();
                cfg.CreateMap<PacketEntity, PacketViewModel>();
                cfg.CreateMap<PacketEntity, Packet>()
                .ForMember(s => s.Modules, opt => opt.Ignore())
                .ForMember(s => s.Packets, opt => opt.Ignore());
                cfg.CreateMap<PacketEntity, PacketItem>()
                //.ForMember(d => d.Script, opt => opt.MapFrom(src => src.Script == null ? "" : src.Script.Substring(0, src.Script.Length >= 80 ? 80 : src.Script.Length) + "..."))
                .ForMember(d => d.Author, opt => opt.MapFrom(src =>
                    $"{src.AspNetUser.LastName} {src.AspNetUser.FirstName[0]}.{src.AspNetUser.Patronymic[0]}."));
                cfg.CreateMap<PacketEntity, FullPacketViewModel>()
                .ForMember(d => d.Script, opt => opt.MapFrom(src => src.Script.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(d => d.Author, opt => opt.MapFrom(src => $"{src.AspNetUser.LastName} {src.AspNetUser.FirstName} {src.AspNetUser.Patronymic}"));

                cfg.CreateMap<AspNetUser, AccountViewModel>()
                .ForMember(d => d.Role, opt => opt.MapFrom(src => src.AspNetRoles.First().Id));
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
                cfg.CreateMap<AspNetUser, AccountViewModel>();
                cfg.CreateMap<AspNetUser, SetAccountPassword>();
            });
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}