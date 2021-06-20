using System;
using Mapster;

namespace Experiments.Domain
{
    [AdaptTo("[name]Dto"), GenerateMapper]
    public class Cat
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
    }
}