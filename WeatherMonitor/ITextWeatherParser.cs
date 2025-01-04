namespace WeatherMonitor;

public interface ITextWeatherParser
{
    public WeatherData? Parse(string text);
}