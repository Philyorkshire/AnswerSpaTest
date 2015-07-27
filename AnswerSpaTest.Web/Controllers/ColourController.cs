namespace AnswerSpaTest.Web.Controllers
{
	using System.Web.Http;
	using Service.Services;

	[RoutePrefix("api/colours")]
	public class ColourController : ApiController
	{
		private readonly ColourService _colourService;

		public ColourController(ColourService colourService)
		{
			_colourService = colourService;
		}

		[Route]
		public IHttpActionResult GetAll()
		{
			var colours = _colourService.GetAll();
			if (colours != null)
			{
				return Ok(colours);
			}

			return NotFound();
		}
	}
}