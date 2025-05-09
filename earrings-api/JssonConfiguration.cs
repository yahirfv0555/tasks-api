﻿namespace earrings_api
{
    public class JsonConfiguration
    {
        public static IConfiguration AppSetting { get; }

        static JsonConfiguration()
        {
            AppSetting = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
        }

        public static string GetEnvironment()
        {
            return AppSetting["Environment"] ?? "";
        }
    }
}
