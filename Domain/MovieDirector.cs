namespace Domain
{
    public class MovieDirector
	{
		public string MovieId { get; set; }
		public Movie Movie { get; set; }
		public string DirectorId { get; set; }
		public Person Director { get; set; }
	}
}