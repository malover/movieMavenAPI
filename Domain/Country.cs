namespace Domain
{
    public class Country : BaseEntity
	{
		public string Name { get; set; }
		
		public ICollection<MovieCountry> MovieCountries{ get; set; }
    }
}