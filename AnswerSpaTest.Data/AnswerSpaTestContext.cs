namespace AnswerSpaTest.Data
{
	using System.Data.Entity;
	using System.Reflection;
	using Domain;

	public class AnswerSpaTestContext : DbContext
    {
		public DbSet<Person> People { get; set; }
		public DbSet<Colour> Colours { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
			Database.SetInitializer<AnswerSpaTestContext>(null);
		}
    }
}
