namespace AnswerSpaTest.Data.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using Domain;

	public class ColourRepository
	{
		private readonly AnswerSpaTestContext _context;

		public ColourRepository(AnswerSpaTestContext context)
		{
			_context = context;
		}

		public ICollection<Colour> GetAll()
		{
			return _context.Colours.ToList();
		}

		public Colour GetById(int id)
		{
			return _context.Colours.Find(id);
		}
	}
}
