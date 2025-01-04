namespace WeatherMonitor;

public class WeatherData
{
    public string Location { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }

    public WeatherData()
    {
        
    }
    
    public WeatherData(string location, float temperature, float humidity)
    {
        Location = location;
        Temperature = temperature;
        Humidity = humidity;
    }
}