using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieCollection
    {

        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}