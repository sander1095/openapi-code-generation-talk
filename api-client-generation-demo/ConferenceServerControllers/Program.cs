using System.Text.Json.Serialization;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7135");

builder.Services.AddControllers();

// The web defaults allow reading numbers from strings, which makes the OpenAPI document describe
// every int as `"type": ["integer", "string"]`. Strict number handling keeps it a plain integer.
builder.Services.ConfigureHttpJsonOptions(x => x.SerializerOptions.NumberHandling = JsonNumberHandling.Strict);

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-10.0
builder.Services.AddOpenApi(x =>
{
    x.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    x.AddDocumentTransformer((document, _, _) =>
    {
        document.Info.Title = "Conference API";
        return Task.CompletedTask;
    });
});

var app = builder.Build();
app.MapOpenApi(); // https://localhost:7135/openapi/v1.json
app.MapScalarApiReference(x => x.WithTitle("Conference API")); // https://localhost:7135/scalar

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
