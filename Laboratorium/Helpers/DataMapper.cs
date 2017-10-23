using System;
using System.Linq;
using AutoMapper;
using Laboratorium.Controllers;
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
                cfg.CreateMap<PacketViewModel, Packet>();

                cfg.CreateMap<AspNetUser, AccountViewModel>()
                .ForMember(d => d.Role, opt => opt.MapFrom(src => src.AspNetRoles.First().Id));
                cfg.CreateMap<AspNetUser, SetAccountPassword>();

                cfg.CreateMap<Script, ScriptViewModel>()
                .ForMember(d => d.Code, opt => opt.MapFrom(src => src.Code.Substring(0, src.Code.Length >= 80 ? 80 : src.Code.Length) + "..."))
                .ForMember(d => d.Author, opt => opt.MapFrom(src =>
                    $"{src.AspNetUser.LastName} {src.AspNetUser.FirstName[0]}.{src.AspNetUser.Patronymic[0]}."));
                cfg.CreateMap<Script, FullScriptViewModel>()
                .ForMember(d => d.Code, opt => opt.MapFrom(src => src.Code.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(d => d.Author, opt => opt.MapFrom(src => $"{src.AspNetUser.LastName} {src.AspNetUser.FirstName} {src.AspNetUser.Patronymic}"));
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