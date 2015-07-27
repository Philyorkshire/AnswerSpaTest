namespace AnswerSpaTest.Service.Services
{
	using System.Collections.Generic;
	using Data.Repositories;
	using Domain;
	using Domain.Dtos;

	public class PersonService
	{
		private readonly PersonRepository _personRepository;
		private readonly ColourService _colourService;

		public PersonService(PersonRepository personRepository, ColourService colourService)
		{
			_personRepository = personRepository;
			_colourService = colourService;
		}

		public Person Get(int id)
		{
			return _personRepository.GetById(id);
		}

		public ICollection<Person> GetAll()
		{
			return _personRepository.GetAll();
		}

		public PersonDto UpdatePerson(int id, PersonDto personDto)
		{
			var personFind = _personRepository.GetById(id);
			personFind.FavouriteColours.Clear();

			if (personDto.FavouriteColours != null)
			{
				foreach (var colourId in personDto.FavouriteColours)
				{
					var colour = _colourService.GetById(colourId);
					personFind.FavouriteColours.Add(colour);
				}
			}

			personFind.IsAuthorised = personDto.IsAuthorised;
			personFind.IsEnabled = personDto.IsEnabled;
			personFind.IsValid = personDto.IsValid;

			_personRepository.SaveChanges();

			return personDto;
		}
	}
}
