namespace AnswerSpaTest.Data.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using Domain;

	public class PersonRepository
	{
		private readonly AnswerSpaTestContext _context;

		public PersonRepository(AnswerSpaTestContext context)
		{
			_context = context;
		}

		public Person GetById(int id)
		{
			return _context.People.Find(id);
		}

		public ICollection<Person> GetAll()
		{
			return _context.People.ToList();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
