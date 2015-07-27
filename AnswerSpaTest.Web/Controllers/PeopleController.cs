namespace AnswerSpaTest.Web.Controllers
{
	using System.Web.Http;
	using Domain.Dtos;
	using Service.Services;

	[RoutePrefix("api/people")]
	public class PeopleController : ApiController
	{
		private readonly PersonService _personService;

		public PeopleController(PersonService personService)
		{
			_personService = personService;
		}

		[Route]
		public IHttpActionResult GetAllPeople()
		{
			var people = _personService.GetAll();
			if (people != null)
			{
				return Ok(people);
			}

			return NotFound();
		}

		[Route("{id}")]
		public IHttpActionResult GetPersonById(int id)
		{
			var person = _personService.Get(id);
			if (person != null)
			{
				return Ok(person);
			}

			return NotFound();
		}

		[HttpPut]
		[Route("{id}")]
		public IHttpActionResult UpdatePerson(int id, [FromBody] PersonDto person)
		{
			var responsePerson = _personService.UpdatePerson(id, person);

			if (responsePerson == null)
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
