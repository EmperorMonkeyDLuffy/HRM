namespace Hrm.Helpers
{
    public static class AppSettings
    {
        public static IConfiguration GlobalConfiguration { get; set; }
        public static TTvalue GetValue<TTvalue>(string key)
        {
            return GlobalConfiguration.GetValue<TTvalue>(key);
        }
    }
}
