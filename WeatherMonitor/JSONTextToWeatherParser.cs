using System.Text.Json;

namespace WeatherMonitor;

public class JsonTextToWeatherParser : ITextWeatherParser
{
    public WeatherData? Parse(string json)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            WeatherData? weather = JsonSerializer.Deserialize<WeatherData>(json, options);

            if (weather is null)
            {
                Console.WriteLine("Failed to parse JSON.");
                return null;
            }
            else
            {
                return weather;
            }
        } 
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (JsonException ex)
        {
            return null;
        }

        return null;
    }
}