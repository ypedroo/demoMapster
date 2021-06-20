using System.Collections.Generic;
using Experiments.Domain;

namespace Experiments.Domain
{
    public static partial class CatMapper
    {
        public static CatDto AdaptToDto(this Cat p1)
        {
            return p1 == null ? null : new CatDto()
            {
                CatId = p1.CatId,
                Name = p1.Name,
                Age = p1.Age,
                Race = p1.Race,
                FavoriteToy = p1.FavoriteToy,
                Owners = funcMain1(p1.Owners)
            };
        }
        public static CatDto AdaptTo(this Cat p3, CatDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            CatDto result = p4 ?? new CatDto();
            
            result.CatId = p3.CatId;
            result.Name = p3.Name;
            result.Age = p3.Age;
            result.Race = p3.Race;
            result.FavoriteToy = p3.FavoriteToy;
            result.Owners = funcMain2(p3.Owners, result.Owners);
            return result;
            
        }
        
        private static List<PersonDto> funcMain1(List<Person> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<PersonDto> result = new List<PersonDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                Person item = p2[i];
                result.Add(item == null ? null : new PersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone
                });
                i++;
            }
            return result;
            
        }
        
        private static List<PersonDto> funcMain2(List<Person> p5, List<PersonDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<PersonDto> result = new List<PersonDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                Person item = p5[i];
                result.Add(item == null ? null : new PersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone
                });
                i++;
            }
            return result;
            
        }
    }
}