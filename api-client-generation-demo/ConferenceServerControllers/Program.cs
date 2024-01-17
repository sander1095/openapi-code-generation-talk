var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7135");

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(x => x.Title = "Conference API");

var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
