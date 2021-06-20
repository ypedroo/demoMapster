using Experiments.Domain;

namespace Experiments.Domain
{
    public static partial class PersonMapper
    {
        public static PersonDto AdaptToDto(this Person p1)
        {
            return p1 == null ? null : new PersonDto()
            {
                Id = p1.Id,
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Phone = p1.Phone
            };
        }
        public static PersonDto AdaptTo(this Person p2, PersonDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PersonDto result = p3 ?? new PersonDto();
            
            result.Id = p2.Id;
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Phone = p2.Phone;
            return result;
            
        }
    }
}