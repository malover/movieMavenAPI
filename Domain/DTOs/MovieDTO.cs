namespace Domain.DTOs
{
	public class MovieDTO
	{
		public string Id { get; set; }
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

		public List<MovieCountryDTO> MovieCountries { get; set; }
		public List<MovieGenreDTO> MovieGenres { get; set; }
		public List<MovieDirectorDTO> MovieDirectors { get; set; }
		public List<MovieActorDTO> MovieActors { get; set; }
		public List<MovieDTO> RelatedMovies{ get; set; }

    }
}