namespace AnswerSpaTest.Data.Mappings
{
	using System.Data.Entity.ModelConfiguration;
	using Domain;

	public class PersonMapping : EntityTypeConfiguration<Person>
	{
		public PersonMapping()
		{
			ToTable("People");
			HasKey(p => p.Id);

			Property(x => x.Id).HasColumnName("PersonId");
			HasMany(x => x.FavouriteColours).WithMany().Map(x => x.ToTable("FavouriteColours").MapLeftKey("PersonId").MapRightKey("ColourId"));
		}
	}
}
