namespace WeatherMonitor;

public class BotConfig
{
    public bool enabled { get; set; }
    public float? humidityThreshold { get; set; }
    public float? temperatureThreshold { get; set; }
    public string message { get; set; }
}