using Laboratorium.Models.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;
using Laboratorium.Core;

namespace Laboratorium
{
    public class DataMapper
    {
        private Mapper _mapper; 
        public DataMapper()
        {

            //var item = new MapperConfigurationExpression();
            //item.CreateMap();
            //MapperConfiguration config = new MapperConfiguration();

            //CreatePacketMap();

            //_mapper = Mapper.Instance();
        }

        private void CreatePacketMap()
        {

        }

        public TDestination GetWrapper<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}