namespace Destiny.Net.Test.Configuration
{
    public interface IConfigurationProvider
    {
        string GetConfigurationVariable(string variable);
    }
}