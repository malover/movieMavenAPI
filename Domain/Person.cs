namespace Domain
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MovieActor> ActorMovies { get; set; }
        public ICollection<MovieDirector> DirectorMovies { get; set; }
    }
}