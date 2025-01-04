namespace WeatherMonitor;

public class RainBotService : IBotService
{
    public BotConfig? _config { get; set; }

    public RainBotService(BotConfig? config)
    {
        _config = config;
    }
    
    public void SendMessage(WeatherData weatherData)
    {
        if (_config == null)
        {
            Console.WriteLine("No Config found found for " + nameof(RainBotService));
            return;
        }

        if (!_config.enabled)
        {
            Console.WriteLine("RainBot is not enabled");
            return;
        }

        if (weatherData.Humidity >= _config.humidityThreshold) {
            Console.WriteLine(_config.message);
        }
        
    }
}