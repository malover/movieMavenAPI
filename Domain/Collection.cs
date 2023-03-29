using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
	public class Collection : BaseEntity
	{
		public string Name { get; set; }
		public string ImgUrl { get; set; }
		public string Description { get; set; }
        public ICollection<MovieCollection> MovieCollections { get; set; }
	}
}