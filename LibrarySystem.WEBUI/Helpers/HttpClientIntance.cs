namespace LibrarySystem.WEBUI.Helpers
{
    public static class HttpClientIntance
    {
        public static  HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7086/api/");
            return client;
        }

    }
}
