using System;
using System.Collections.Generic;
using Mapster;

namespace Experiments.Domain
{
    [AdaptTo("CatDto"), GenerateMapper]
    public class Cat
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
        public List<Person> Owners { get; set; }
    }
}