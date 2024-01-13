using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/openapi?view=aspnetcore-8.0
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApiDocument(x => x.Title = "Conference API");
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.MapGet("api/talks", GetTalks)
    .WithName("Talks_GetTalks")
    .WithOpenApi()
    .WithTags("Talks")
    .Produces<IReadOnlyCollection<Talk>>(StatusCodes.Status200OK);

app.MapGet("api/talks/{id:int:min(1)}", GetTalk)
    .WithName("Talks_GetTalk")
    .WithOpenApi()
    .WithTags("Talks")
    .Produces<Talk>(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status404NotFound);

app.MapPost("api/talks", CreateTalk)
    .WithName("Talks_CreateTalk")
    .WithOpenApi()
    .WithTags("Talks")
    .Produces<Talk>(StatusCodes.Status200OK)
    .ProducesValidationProblem(StatusCodes.Status400BadRequest)
    .ProducesProblem(StatusCodes.Status409Conflict);

static IResult GetTalks()
{
    return TypedResults.Ok<IReadOnlyCollection<Talk>>(TalkDatabase.Talks);
}

static IResult GetTalk(int id)
{
    var talk = TalkDatabase.Talks.FirstOrDefault(x => x.Id == id);
    if (talk == null)
    {
        return TypedResults.NotFound();
    }

    return TypedResults.Ok(talk);
}

static IResult CreateTalk(CreateTalk requestBody)
{
    // TODO: Validate this better..
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(requestBody, new ValidationContext(requestBody), validationResults))
    {
        return TypedResults.ValidationProblem(new Dictionary<string, string[]> { { "Title", ["Title is too long"] } });
    }

    if (TalkDatabase.Talks.Any(x => x.Title == requestBody.Title))
    {
        return TypedResults.Problem(statusCode: StatusCodes.Status409Conflict);
    }

    var newTalk = new Talk() { Id = TalkDatabase.Talks.Count + 1, Title = requestBody.Title };
    TalkDatabase.Talks.Add(newTalk);

    return TypedResults.Ok(newTalk);
}


app.Run();

internal static class TalkDatabase
{
    public static List<Talk> Talks = [
        new() { Id = 1, Title = "OpenAPI" },
        new() { Id = 2, Title = "Sustainable Software" },
        new() { Id = 3, Title = "Code dependencies" },
        new() { Id = 4, Title = "Open source" },
        new() { Id = 5, Title = "Security Scorecards" },
        new() { Id = 6, Title = "Entra" },
        new() { Id = 7, Title = "Github Codespaces" }
    ];
}

internal class Talk
{
    public required int Id { get; set; }
    public required string Title { get; set; }
}

internal class CreateTalk
{
    [StringLength(100)]
    public required string Title { get; set; }
}