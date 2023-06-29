namespace Client.Helper
{
    public class ApiHelper
    {
        public HttpClient Client()
        {
            var client = new HttpClient();
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Directory.GetCurrentDirectory());
            configurationManager.AddJsonFile("appsettings.json");
            var baseAddress = configurationManager.GetSection("AppSettings:BaseUrl").Value!;
            client.BaseAddress = new Uri(baseAddress);
            return client;
        }
    }
}
