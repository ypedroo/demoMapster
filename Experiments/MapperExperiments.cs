using System;
using System.Collections.Generic;
using AutoMapper;
using BenchmarkDotNet.Disassemblers;
using Experiments.Domain;
using Experiments.Dtos;
using Mapster;
// using CatDto = Experiments.Domain.CatDto;

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
            Race = "Siamese",
            Owners = new List<Person>
            {
                new()
                {
                    Id = new Guid(),
                    FirstName = "ynoa",
                    LastName = "mota",
                    Phone = "8599999999"
                },
                new()
                {
                    Id = new Guid(),
                    FirstName = "pedro",
                    LastName = "lourenco",
                    Phone = "8599999999"
                }
            }
        };

        private static readonly TypeAdapterConfig typeAdapterConfig = GetMapsterConfig();

        private static readonly IMapper AutoMapper =
            new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutoMapperProfile())));

        private static readonly MapsterMapper.IMapper MapsterConfig = new MapsterMapper.Mapper(typeAdapterConfig);

        // https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping
        public static TypeAdapterConfig GetMapsterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Cat, CatDtoWritten>();
            return config;
        }

        // public static CatDto MapsterCodegenexperiment()
        // {
        //     return RegularCat.AdaptToDto();
        // }
        
        
        // dotnet new tool-manifest
        // dotnet tool install Mapster.Tool

        public static CatDtoWritten MapsterAdaptWithConfigurationExperiment()
        {
            return MapsterConfig.From(RegularCat).AdaptToType<CatDtoWritten>();
        }

        public static CatDtoWritten MapsterAdaptExperiment()
        {
            return RegularCat.Adapt<CatDtoWritten>();
        }

        public MapperExperiments()
        {
            ExpressMapper.Mapper.Register<Cat, CatDtoWritten>();
        }

        public static CatDtoWritten AutoMapperExperiment()
        {
            return AutoMapper.Map<CatDtoWritten>(RegularCat);
        }

        public static CatDtoWritten ExpressMapperExperiment()
        {
            return ExpressMapper.Mapper.Map<Cat, CatDtoWritten>(RegularCat);
        }

        public static CatDtoWritten ManualMapperExperiment()
        {
            var catDto = new CatDtoWritten()
            {
                Age = RegularCat.Age,
                FavoriteToy = RegularCat.FavoriteToy,
                Name = RegularCat.Name,
                Race = RegularCat.Race,
                CatId = RegularCat.CatId
            };
            foreach (var i in RegularCat.Owners)
            {
                catDto.Owners.Add(i);
            }

            return catDto;
        }

        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Cat, CatDtoWritten>();
            }
        }
    }
}