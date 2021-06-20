using System;
using System.Collections.Generic;
using Experiments.Domain;

namespace Experiments.Dtos
{
    public class CatDtoWritten
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string FavoriteToy { get; set; }
        public List<Person> Owners { get; set; }
    }
}