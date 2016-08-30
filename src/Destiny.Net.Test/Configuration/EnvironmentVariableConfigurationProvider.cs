using System;

namespace Destiny.Net.Test.Configuration
{
    public class EnvironmentVariableConfigurationProvider : IConfigurationProvider
    {
        public string GetConfigurationVariable(string variable)
        {
            var token = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User);

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception(variable);
            }

            return token;
        }
    }
}
