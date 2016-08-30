using System;

namespace Destiny.Net.Test.Configuration
{
    public class DestinyApiKeyProvider
    {
        readonly IConfigurationProvider _configurationProvider;

        public DestinyApiKeyProvider(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public const string ApiKeyVariable = "DestinyApiKey";
        
        public string GetApiKey()
        {
            try
            {
                var apiKey = _configurationProvider.GetConfigurationVariable(ApiKeyVariable);

                return apiKey;
            }
            catch (Exception)
            {
                throw new DesktinyApiKeyProviderException();
            }
        }
    }
}