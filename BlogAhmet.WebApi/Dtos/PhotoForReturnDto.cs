using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAhmet.WebApi.Dtos
{
    public class PhotoForReturnDto
    {

        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string DateAdded { get; set; }

        public string PublicId { get; set; }



    }
}
