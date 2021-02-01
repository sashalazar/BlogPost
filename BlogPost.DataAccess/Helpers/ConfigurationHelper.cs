using Microsoft.Extensions.Configuration;
using System;

namespace BlogPost.DataAccess.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            return builder.Build();
        }
    }
}
