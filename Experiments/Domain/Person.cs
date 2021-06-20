using System;
using Mapster;

namespace Experiments.Domain
{
    [AdaptTo("PersonDto"), GenerateMapper]
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}