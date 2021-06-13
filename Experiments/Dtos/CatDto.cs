using System;

namespace Experiments.Dtos
{
    public class CatDto
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
    }
}