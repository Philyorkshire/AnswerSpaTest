namespace AnswerSpaTest.Data.Mappings
{
	using System.Data.Entity.ModelConfiguration;
	using Domain;

	public class ColourMapping : EntityTypeConfiguration<Colour>
	{
		public ColourMapping()
		{
			ToTable("Colours");
			HasKey(c => c.Id);

			Property(x => x.Id).HasColumnName("ColourId");
		}
	}
}
