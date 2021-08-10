using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Utility
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapObject<TSource, TDestination>(TSource Value)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDestination>(); });
            IMapper iMapper = config.CreateMapper();
            return ((TDestination)iMapper.Map<TSource, TDestination>(Value));
        }

        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDestination>(); });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<List<TDestination>>(source);
        }
    }
}
