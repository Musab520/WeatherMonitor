namespace WeatherMonitor {
    
    public class WeatherMonitor : Monitor {
        
        List<IBotService> botServices = new List<IBotService>();

        public void addBot(IBotService botService)
        {
            botServices.Add(botService);
        }

        public void removeBot(IBotService botService)
        {
            botServices.Remove(botService);
        }

        public void noifyBots(WeatherData weatherData)
        {
            botServices
                .ForEach(bot => bot.SendMessage(weatherData));
        }
    }

}