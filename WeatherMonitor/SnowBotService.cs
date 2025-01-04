namespace WeatherMonitor;

public class SnowBotService : IBotService
{
    public BotConfig? _config { get; set; }

    public SnowBotService(BotConfig? config)
    {
        _config = config;
    }
    
    public void SendMessage(WeatherData weatherData)
    {
        if (_config == null)
        {
            Console.WriteLine("No Config found found for " + nameof(SnowBotService));
            return;
        }

        if (!_config.enabled)
        {
            Console.WriteLine("SnowBot is not enabled");
            return;
        }

        if (weatherData.Temperature >= _config.temperatureThreshold) {
            Console.WriteLine(_config.message);
        }
        
    }
}