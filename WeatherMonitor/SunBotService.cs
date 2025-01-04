namespace WeatherMonitor;

public class SunBotService : IBotService
{
    public BotConfig? _config { get; set; }

    public SunBotService(BotConfig? config)
    {
        _config = config;
    }
    
    public void SendMessage(WeatherData weatherData)
    {
        if (_config == null)
        {
            Console.WriteLine("No Config found found for " + nameof(SunBotService));
            return;
        }

        if (!_config.enabled)
        {
            Console.WriteLine("SunBot is not enabled");
            return;
        }

        if (weatherData.Temperature >= _config.temperatureThreshold) {
            Console.WriteLine(_config.message);
        }
        
    }
}