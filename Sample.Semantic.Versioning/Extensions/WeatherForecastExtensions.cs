namespace Sample.Semantic.Versioning.Extensions;

public static partial class WeatherForecastApi
{
    /// <summary>
    /// Maps the weather forecast endpoint to the application.
    /// </summary>
    /// <param name="app">The web application.</param>
    public static void MapWeatherForecastEndpoint(this WebApplication app)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi()
        .Produces<WeatherForecast[]>(StatusCodes.Status200OK);

        app.MapGet("/weatherforecast/{id:int}", (int id) =>
        {
            var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(id)), 0, "Unknown");
            return forecast;
        })
        .WithName("GetWeatherForecastById")
        .WithOpenApi()
        .Produces<WeatherForecast>(StatusCodes.Status200OK);
    }
}
