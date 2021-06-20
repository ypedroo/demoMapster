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
        private static readonly Cat RegularCat = new()
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
            config.NewConfig<Cat, Dtos.CatDto>();
            return config;
        }

        public static Domain.CatDto MapsterCodegenexperiment()
        {
            return RegularCat.AdaptToDto();
        }
        // dotnet new tool-manifest
        // dotnet tool install Mapster.Tool

        public static Dtos.CatDto MapsterAdaptWithConfigurationExperiment()
        {
            return MapsterConfig.From(RegularCat).AdaptToType<Dtos.CatDto>();
        }

        public static Dtos.CatDto MapsterAdaptExperiment()
        {
            return RegularCat.Adapt<Dtos.CatDto>();
        }

        public MapperExperiments()
        {
            ExpressMapper.Mapper.Register<Cat, Dtos.CatDto>();
        }

        public static Dtos.CatDto AutoMapperExperiment()
        {
            return AutoMapper.Map<Dtos.CatDto>(RegularCat);
        }

        public static Dtos.CatDto ExpressMapperExperiment()
        {
            return ExpressMapper.Mapper.Map<Cat, Dtos.CatDto>(RegularCat);
        }

        public static Dtos.CatDto ManualMapperExperiment()
        {
            var cat = RegularCat;
            return new Dtos.CatDto()
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
                CreateMap<Cat, Dtos.CatDto>();
            }
        }

    }
}