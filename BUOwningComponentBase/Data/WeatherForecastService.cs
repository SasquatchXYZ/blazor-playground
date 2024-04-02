namespace BUOwningComponentBase.Data;

public class WeatherForecastService
{
    private volatile int Locked;

    private static readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        if (Interlocked.CompareExchange(ref Locked, 1, 0) > 0)
            throw new InvalidOperationException(
                "A second operation started on this context before a previous operation completed.  Any"
                + "instance members are not guaranteed to be thread-safe.");

        try
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
            await Task.Delay(3000);
            var startDateOnly = DateOnly.FromDateTime(startDate);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDateOnly.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            }).ToArray();
        }
        finally
        {
            Interlocked.Decrement(ref Locked);
        }
    }
}
