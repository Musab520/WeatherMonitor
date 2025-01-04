using System.Text.Json;

namespace WeatherMonitor
{
    class Program
    {
        static void Main()
        {
            BotConfigs? botConfigs = null;
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectRootPath = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            
            try
            {
                string json = File.ReadAllText(projectRootPath + "/config.json");
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                botConfigs = JsonSerializer.Deserialize<BotConfigs>(json, options);
                if (botConfigs == null)
                {
                    Console.WriteLine("Failed to deserialize JSON.");
                    return;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
            
            
            IBotService rainBotService = new RainBotService(botConfigs.RainBot);
            IBotService sunBotService = new SunBotService(botConfigs.SunBot);
            IBotService snowBotService = new SnowBotService(botConfigs.SnowBot);

            WeatherMonitor monitor = new WeatherMonitor();
            monitor.addBot(rainBotService);
            monitor.addBot(sunBotService);
            monitor.addBot(snowBotService);
            while (true)
            {
                Console.WriteLine("Please enter the weather data in JSON or XML format:");
                string? line = Console.ReadLine();
                string text = "";
                while (!string.IsNullOrWhiteSpace(line))
                {
                    text += line + "\n";
                    line = Console.ReadLine();
                }

                if (text.Trim() == "END")
                {
                    break;
                }
                
                string? json = null;
                string? xml = null;

                ITextWeatherParser parser = new JsonTextToWeatherParser();
                WeatherData? weatherData = parser.Parse(text);

                if (weatherData == null)
                {
                    parser = new XmlTextToWeatherParser();
                    weatherData = parser.Parse(text);
                }

                if (weatherData == null)
                {
                    continue;
                }
                
                monitor.noifyBots(weatherData);
            }

        }
    }
}