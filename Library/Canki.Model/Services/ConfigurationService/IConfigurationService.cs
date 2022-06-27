using Microsoft.Extensions.Configuration;

namespace Canki.Model.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
