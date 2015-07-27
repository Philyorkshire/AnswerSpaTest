namespace AnswerSpaTest.Domain
{
	using System.Collections.Generic;
	using Base;

	public class Person : Entity
	{
		public Person()
		{
			FavouriteColours = new List<Colour>();
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public bool IsAuthorised { get; set; }
		public bool IsValid { get; set; }

		public virtual ICollection<Colour> FavouriteColours { get; set; }
	}
}
