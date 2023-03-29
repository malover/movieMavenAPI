using AutoMapper;
using Domain;
using Domain.DTOs;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieCountry, MovieCountryDTO>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<MovieGenre, MovieGenreDTO>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<MovieDirector, MovieDirectorDTO>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name));
            CreateMap<MovieActor, MovieActorDTO>()
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Actor.Name));
            CreateMap<Movie, MovieDTO>()
            .ForMember(dest => dest.RelatedMovies,
                       opt => opt.MapFrom(src => src.ParentMovie.RelatedMovies.Where(rm => rm.Id != src.Id)));
        }
    }
}