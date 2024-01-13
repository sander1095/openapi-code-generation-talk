using ConferenceServerControllers.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceServerControllers.Controllers
{
    // https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/analyzers?view=aspnetcore-8.0
    [ApiController]
    [Route("api/talks")]
    public class TalksController : ControllerBase
    {
        private static readonly List<Talk> _talks = [
            new() { Id = 1, Title = "OpenAPI" },
            new() { Id = 2, Title = "Sustainable Software" },
            new() { Id = 3, Title = "Code dependencies" },
            new() { Id = 4, Title = "Open source" },
            new() { Id = 5, Title = "Security Scorecards" },
            new() { Id = 6, Title = "Entra" },
            new() { Id = 7, Title = "Github Codespaces" }
            ];

        [HttpGet]
        [ProducesResponseType<IReadOnlyCollection<Talk>>(StatusCodes.Status200OK)]
        public ActionResult<IReadOnlyCollection<Talk>> GetTalks()
        {
            return Ok(_talks);
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType<Talk>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Talk> GetTalk(int id)
        {
            var talk = _talks.FirstOrDefault(x => x.Id == id);
            if (talk == null)
            {
                // Comment out the 404 response type to get the following warning
                // thanks to <IncludeOpenAPIAnalyzers> in the csproj.
                // Warning API1000 Action method returns undeclared status code '404' 
                return NotFound();
            }

            return Ok(talk);
        }

        [HttpPost]
        [ProducesResponseType<Talk>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<Talk> CreateTalk(CreateTalk requestBody)
        {
            // 400 bad request validation is done automatically thanks to [ApiController]

            if (_talks.Any(x => x.Title == requestBody.Title))
            {
                return Conflict();
            }

            var newTalk = new Talk() { Id = _talks.Count + 1, Title = requestBody.Title };
            _talks.Add(newTalk);

            return Ok(newTalk);
        }
    }
}
