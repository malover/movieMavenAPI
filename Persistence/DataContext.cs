using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<MovieGenre> MovieGenres { get; set; }
		public DbSet<MovieCountry> MovieCountries { get; set; }
		public DbSet<MovieDirector> MovieDirectors { get; set; }
		public DbSet<MovieActor> MovieActors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//MovieCountries
			modelBuilder.Entity<MovieCountry>()
				.HasKey(mc => new { mc.MovieId, mc.CountryId });

			modelBuilder.Entity<MovieCountry>()
				.HasOne(mc => mc.Movie)
				.WithMany(m => m.MovieCountries)
				.HasForeignKey(mc => mc.MovieId);

			modelBuilder.Entity<MovieCountry>()
				.HasOne(mc => mc.Country)
				.WithMany(c => c.MovieCountries)
				.HasForeignKey(mc => mc.CountryId);

			//MovieGenres table
			modelBuilder.Entity<MovieGenre>()
				.HasKey(ma => new { ma.MovieId, ma.GenreId });

			modelBuilder.Entity<MovieGenre>()
				.HasOne(mg => mg.Movie)
				.WithMany(m => m.MovieGenres)
				.HasForeignKey(mg => mg.MovieId);

			modelBuilder.Entity<MovieGenre>()
				.HasOne(mg => mg.Genre)
				.WithMany(g => g.MovieGenres)
				.HasForeignKey(mg => mg.GenreId);

			//MovieActors table
			modelBuilder.Entity<MovieActor>()
				.HasKey(ma => new { ma.MovieId, ma.ActorId });

			modelBuilder.Entity<MovieActor>()
				.HasOne(ma => ma.Movie)
				.WithMany(m => m.MovieActors)
				.HasForeignKey(ma => ma.MovieId);

			modelBuilder.Entity<MovieActor>()
				.HasOne(ma => ma.Actor)
				.WithMany(p => p.ActorMovies)
				.HasForeignKey(ma => ma.ActorId);

			//MovieDirectors table
			modelBuilder.Entity<MovieDirector>()
				.HasKey(md => new { md.MovieId, md.DirectorId });

			modelBuilder.Entity<MovieDirector>()
				.HasOne(md => md.Movie)
				.WithMany(m => m.MovieDirectors)
				.HasForeignKey(md => md.MovieId);

			modelBuilder.Entity<MovieDirector>()
				.HasOne(md => md.Director)
				.WithMany(p => p.DirectorMovies)
				.HasForeignKey(md => md.DirectorId);

            //MovieCollections table
            modelBuilder.Entity<MovieCollection>()
            .HasKey(md => new { md.MovieId, md.CollectionId });

            modelBuilder.Entity<MovieCollection>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.MovieCollections)
                .HasForeignKey(md => md.MovieId);

            modelBuilder.Entity<MovieCollection>()
                .HasOne(md => md.Collection)
                .WithMany(p => p.MovieCollections)
                .HasForeignKey(md => md.CollectionId);
			
			//Movie related
			modelBuilder.Entity<Movie>()
				.HasOne(m => m.ParentMovie)
				.WithMany(m => m.RelatedMovies)
				.HasForeignKey(m => m.ParentMovieId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}