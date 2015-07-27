namespace AnswerSpaTest.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Domain;

	internal sealed class Configuration : DbMigrationsConfiguration<AnswerSpaTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AnswerSpaTestContext context)
        {
			var people = new List<Person>
            {
                new Person() { Id = 1, FirstName = "Willis", LastName = "Tibbs", IsAuthorised = true, IsValid = true, IsEnabled = false },
                new Person() { Id = 2, FirstName = "Sharon", LastName = "Halt", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person() { Id = 3, FirstName = "Patrick", LastName = "Kerr", IsAuthorised = true, IsValid = true, IsEnabled = true },
                new Person() { Id = 4, FirstName = "Lilly", LastName = "Hale", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person() { Id = 5, FirstName = "Joel", LastName = "Daly", IsAuthorised = true, IsValid = true, IsEnabled = true },
                new Person() { Id = 6, FirstName = "Imogen", LastName = "Kent", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person() { Id = 7, FirstName = "George", LastName = "Edwards", IsAuthorised = true, IsValid = true, IsEnabled = false },
                new Person() { Id = 8, FirstName = "Gabriel", LastName = "Francis", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person() { Id = 9, FirstName = "Courtney", LastName = "Arnold", IsAuthorised = true, IsValid = true, IsEnabled = true },
                new Person() { Id = 10, FirstName = "Brian", LastName = "Allen", IsAuthorised = true, IsValid = true, IsEnabled = true },
                new Person() { Id = 11, FirstName = "Bo", LastName = "Bob", IsAuthorised = true, IsValid = true, IsEnabled = false }
            };

			// ADD COLOURS
			var colours = new List<Colour>
            {
                new Colour() {Id = 1, Name = "Red", IsEnabled = true},
                new Colour() {Id = 2, Name = "Green", IsEnabled = true},
                new Colour() {Id = 3, Name = "Blue", IsEnabled = true}
            };

			foreach (var colour in colours)
			{
				context.Colours.AddOrUpdate(colour);
			}

			foreach (var person in people)
			{
				person.FavouriteColours.Add(colours[0]);
				person.FavouriteColours.Add(colours[1]);
				person.FavouriteColours.Add(colours[2]);
				context.People.AddOrUpdate(person);
			}

			context.SaveChanges();
        }
    }
}
