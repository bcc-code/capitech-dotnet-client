using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Tests
{
    public class ConfigHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("8adda8b3-6dfd-4131-95c0-5d3729edec3e")
                .AddEnvironmentVariables()
                .Build();
        }

        public static CapitechOptions GetApplicationConfiguration(string outputPath)
        {
            var configuration = new CapitechOptions();

            var configRoot = GetIConfigurationRoot(outputPath);

            configRoot
                .GetSection("Capitech")
                .Bind(configuration);

            return configuration;
        }
    }
}
