using Experiments.Domain;
using Experiments.Dtos;

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
                FavoriteToy = p1.FavoriteToy
            };
        }
        public static CatDto AdaptTo(this Cat p2, CatDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CatDto result = p3 ?? new CatDto();
            
            result.CatId = p2.CatId;
            result.Name = p2.Name;
            result.Age = p2.Age;
            result.Race = p2.Race;
            result.FavoriteToy = p2.FavoriteToy;
            return result;
            
        }
    }
}