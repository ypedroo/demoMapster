using System;
using AutoMapper;
using BenchmarkDotNet.Disassemblers;
using Experiments.Domain;
using Experiments.Dtos;
using Mapster;

namespace Experiments
{
    public class MapperExperiments
    {
        private static readonly CatModel RegularCat = new()
        {
            CatId = Guid.NewGuid(),
            Age = 2,
            FavoriteToy = "String from garbage",
            Name = "Leia",
            Race = "Siamese"
        };

        private static readonly TypeAdapterConfig typeAdapterConfig = GetMapsterConfig();

        private static readonly IMapper AutoMapper =
            new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutoMapperProfile())));

        private static readonly MapsterMapper.IMapper MapsterConfig = new MapsterMapper.Mapper(typeAdapterConfig);

        // https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping
        public static TypeAdapterConfig GetMapsterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CatModel, CatDto>();
            return config;
        }

        public static CatDto MapsterAdaptWithConfigurationExperiment()
        {
            return MapsterConfig.From(RegularCat).AdaptToType<CatDto>();
        }

        public static CatDto MapsterAdaptExperiment()
        {
            return RegularCat.Adapt<CatDto>();
        }

        public MapperExperiments()
        {
            ExpressMapper.Mapper.Register<CatModel, CatDto>();
        }

        public static CatDto AutoMapperExperiment()
        {
            return AutoMapper.Map<CatDto>(RegularCat);
        }

        public static CatDto ExpressMapperExperiment()
        {
            return ExpressMapper.Mapper.Map<CatModel, CatDto>(RegularCat);
        }

        public static CatDto ManualMapperExperiment()
        {
            var cat = RegularCat;
            return new CatDto()
            {
                Age = RegularCat.Age,
                FavoriteToy = RegularCat.FavoriteToy,
                Name = RegularCat.Name,
                Race = RegularCat.Race,
                CatId = RegularCat.CatId
            };
        }

        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<CatModel, CatDto>();
            }
        }
    }
}