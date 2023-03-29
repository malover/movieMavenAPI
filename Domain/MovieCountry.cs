using Domain.Core;

namespace Domain
{
    public class MovieCountry
    {
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
    }
}