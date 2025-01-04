namespace WeatherMonitor;

public interface IBotService
{
    public void SendMessage(WeatherData weatherData);
}