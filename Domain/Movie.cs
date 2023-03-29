using Domain.Core;

namespace Domain
{
	public class Movie : BaseEntity
	{
		public string Title { get; set; }
		public string ImgUrl { get; set; }
		public string Description { get; set; }
		public string Slogan { get; set; }
		public string Type { get; set; }
		public string AgeRestriction { get; set; }
		public DateTime ReleaseYear { get; set; }
		public string Language { get; set; }
		public decimal OverallRating { get; set; }
		public decimal AdminRating { get; set; }
		public string ParentMovieId { get; set; }

		public ICollection<MovieCountry> MovieCountries { get; set; }
		public ICollection<MovieGenre> MovieGenres { get; set; }
		public ICollection<MovieDirector> MovieDirectors { get; set; }
		public ICollection<MovieActor> MovieActors { get; set; }
		public ICollection<MovieCollection> MovieCollections{ get; set; }
		public ICollection<Movie> RelatedMovies { get; set; }
		public Movie ParentMovie { get; set; }
		
		public Movie()
		{
            ParentMovieId = Id;
        }
	}
}
