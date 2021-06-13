using System;
using AutoMapper;
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

        private static readonly IMapper AutoMapper =
            new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutoMapperProfile())));

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