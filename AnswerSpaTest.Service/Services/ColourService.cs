namespace AnswerSpaTest.Service.Services
{
	using System.Collections.Generic;
	using Data.Repositories;
	using Domain;

	public class ColourService
	{
		private readonly ColourRepository _colourRepository;

		public ColourService(ColourRepository colourRepository)
		{
			_colourRepository = colourRepository;
		}

		public ICollection<Colour> GetAll()
		{
			return _colourRepository.GetAll();
		}

		public Colour GetById(int id)
		{
			return _colourRepository.GetById(id);
		}
	}
}
