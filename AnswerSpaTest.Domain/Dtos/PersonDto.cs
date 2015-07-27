namespace AnswerSpaTest.Domain.Dtos
{
	using System.Collections.Generic;

	public class PersonDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public bool IsAuthorised { get; set; }
		public bool IsValid { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsPalindrome { get; set; }

		public List<int> FavouriteColours { get; set; }
	}
}
