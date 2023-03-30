using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Movies.Any()) return;

            //Add genres to the database
            var genres = new List<Genre>()
            {
                new Genre {Name = "Comedy"},
                new Genre {Name = "Action"},
                new Genre {Name = "Drama"},
                new Genre {Name = "Thriller"},
                new Genre {Name = "Crime"},
            };

            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();

            //Add countries to the database
            var countries = new List<Country>()
            {
                new Country {Name = "USA"},
                new Country {Name = "Great Britain"},
                new Country {Name = "Spain"},
                new Country {Name = "Ukraine"}
            };

            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync();

            //Add people to the database
            var people = new List<Person>()
            {
                new Person {Name = "Robert De Niro"},
                new Person {Name = "Jack Nicholson"},
                new Person {Name = "Marlon Brando"},
                new Person {Name = "Tim Robins"},
                new Person {Name = "Morgan Freeman"},
                new Person {Name = "Bob Guton"},
                new Person {Name = "Steven Spielberg"},
                new Person {Name = "Martin Scorsese"},
                new Person {Name = "Frank Darabont"},
                new Person {Name = "Francis Ford Coppola"},
                new Person {Name = "Al Pacino"},
                new Person {Name = "James Caan"},
                new Person {Name = "Christopher Nolan"},
                new Person {Name = "Christian Bale"},
                new Person {Name = "Heath Legder"},
                new Person {Name = "Aaron Eckhart"},
            };

            await context.Persons.AddRangeAsync(people);
            await context.SaveChangesAsync();

            //Add movies to the database
            var movies = new List<Movie>()
            {
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ImgUrl = "Image goes here",
                    Description = "Description goes here",
                    Slogan = "Slogan goes here",
                    Type = "Film",
                    AgeRestriction = "R",
                    ReleaseYear = DateTime.UtcNow,
                    Language = "English",
                    OverallRating = 9.3M,
                    AdminRating = 10.0M,
                    MovieGenres = new List<MovieGenre>()
                    {
                        new MovieGenre{GenreId = genres[2].Id}
                    },
                    MovieActors = new List<MovieActor>()
                    {
                        new MovieActor{ActorId = people[3].Id},
                        new MovieActor{ActorId = people[4].Id},
                        new MovieActor{ActorId = people[5].Id}
                    },
                    MovieDirectors = new List<MovieDirector>()
                    {
                        new MovieDirector{DirectorId = people[8].Id}
                    },
                    MovieCountries = new List<MovieCountry>()
                    {
                        new MovieCountry{CountryId = countries[0].Id}
                    }
                },
                new Movie
                {
                    Title = "The Godfather",
                    ImgUrl = "Image goes here",
                    Description = "Description goes here",
                    Slogan = "Slogan goes here",
                    Type = "Film",
                    AgeRestriction = "R",
                    ReleaseYear = DateTime.UtcNow,
            		Language = "English",
                    OverallRating = 9.2M,
                    AdminRating = 9.9M,
                    MovieGenres = new List<MovieGenre>()
                    {
                        new MovieGenre{GenreId = genres[2].Id},
                        new MovieGenre{GenreId = genres[4].Id}
                    },
                    MovieActors = new List<MovieActor>()
                    {
                        new MovieActor{ActorId = people[2].Id},
                        new MovieActor{ActorId = people[10].Id},
                        new MovieActor{ActorId = people[11].Id}
                    },
                    MovieDirectors = new List<MovieDirector>()
                    {
                        new MovieDirector{DirectorId = people[9].Id}
                    },
                    MovieCountries = new List<MovieCountry>()
                    {
                        new MovieCountry{CountryId = countries[0].Id}
                    }
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    ImgUrl = "Image goes here",
                    Description = "Description goes here",
                    Slogan = "Slogan goes here",
                    Type = "Film",
                    AgeRestriction = "PG-13",
                    ReleaseYear = DateTime.UtcNow,
                    Language = "English",
                    OverallRating = 9.3M,
                    AdminRating = 10,
                    MovieGenres = new List<MovieGenre>()
                    {
                        new MovieGenre{GenreId = genres[1].Id},
                        new MovieGenre{GenreId = genres[2].Id},
                        new MovieGenre{GenreId = genres[4].Id},
                    },
                    MovieActors = new List<MovieActor>()
                    {
                        new MovieActor{ActorId = people[13].Id},
                        new MovieActor{ActorId = people[14].Id},
                        new MovieActor{ActorId = people[15].Id}
                    },
                    MovieDirectors = new List<MovieDirector>()
                    {
                        new MovieDirector{DirectorId = people[12].Id}
                    },
                    MovieCountries = new List<MovieCountry>()
                    {
                        new MovieCountry{CountryId = countries[0].Id},
                        new MovieCountry{CountryId = countries[1].Id},
                    }
                }
            };

            await context.Movies.AddRangeAsync(movies);
            await context.SaveChangesAsync();

            var relatedMovie = new Movie
            {
                Title = "The Godfather 2",
                ImgUrl = "Image goes here",
                Description = "Description goes here",
                Slogan = "Slogan goes here",
                Type = "Film",
                AgeRestriction = "R",
                ReleaseYear = DateTime.UtcNow,
                Language = "English",
                OverallRating = 9.2M,
                AdminRating = 9.9M,
                MovieGenres = new List<MovieGenre>()
                {
                    new MovieGenre{GenreId = genres[2].Id},
                    new MovieGenre{GenreId = genres[4].Id}
                },
                MovieActors = new List<MovieActor>()
                {
                    new MovieActor{ActorId = people[2].Id},
                    new MovieActor{ActorId = people[10].Id},
                    new MovieActor{ActorId = people[11].Id}
                },
                MovieDirectors = new List<MovieDirector>()
                {
                    new MovieDirector{DirectorId = people[9].Id}
                },
                MovieCountries = new List<MovieCountry>()
                {
                    new MovieCountry{CountryId = countries[0].Id}
                },
                ParentMovieId = context.Movies.FirstOrDefault(x => x.Title == "The Godfather").Id
            };

            await context.Movies.AddAsync(relatedMovie);
            await context.SaveChangesAsync();
        }
    }
}