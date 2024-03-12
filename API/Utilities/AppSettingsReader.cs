namespace API.Utilities
{
    public class AppSettingsReader
    {
        private IConfigurationRoot JsonSettings { get; set; }
        public AppSettingsReader(string environmentName = "")
        {
            JsonSettings = ReadAppSettingsJson(environmentName);
        }

        private IConfigurationRoot ReadAppSettingsJson(string environmentName)
        {
            var env = environmentName != "" ? $".{environmentName}" : "";
            return new ConfigurationBuilder().AddJsonFile($"appsettings{env}.json").Build();
        }

        public T GetValue<T>(string selector)
        {
            return JsonSettings.GetValue<T>(selector);
        }

        public List<T> GetValues<T>(string selector)
        {
            return JsonSettings.GetSection(selector).Get<List<T>>();
        }
    }
}
