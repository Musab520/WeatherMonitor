using System.Text.Json;
using System.Xml.Serialization;

namespace WeatherMonitor;

public class XmlTextToWeatherParser : ITextWeatherParser
{
    public WeatherData? Parse(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
        StringReader reader = new StringReader(xml);
        WeatherData? weather = (WeatherData?)serializer.Deserialize(reader);

        if (weather is null)
        {
            Console.WriteLine("Failed to parse JSON.");
            return null;
        }

        return weather;
    }
}