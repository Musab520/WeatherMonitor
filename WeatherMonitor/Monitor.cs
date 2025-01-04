namespace WeatherMonitor;

public interface Monitor
{
    void addBot(IBotService botService);
    void removeBot(IBotService botService);
    void noifyBots(WeatherData weatherData);
}