namespace BUOwningComponentBase.Data;

public class WeatherForecastService
{
    private static readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);

        var startDateOnly = DateOnly.FromDateTime(startDate);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDateOnly.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        }).ToArray();
    }
}
