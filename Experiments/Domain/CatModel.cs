using System;

namespace Experiments.Domain
{
    public class CatModel
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
    }
}