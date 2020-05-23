
using BlogAhmet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Entities.Concrete
{
    public class Admin : IEntity
    {

        public int AdminId { get; set; }

        public string AdminNameSurname { get; set; }

        public string AdminUsername { get; set; }

        public string AdminPassword { get; set; }

    }
}
