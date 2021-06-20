using System;
using System.Collections.Generic;
using Experiments.Domain;

namespace Experiments.Domain
{
    public partial class CatDto
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
        public List<PersonDto> Owners { get; set; }
    }
}