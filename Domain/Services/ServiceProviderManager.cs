
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services
{
    public class ServiceProviderManager
    {
        private static ServiceProviderManager Instance;
        private ServiceProvider _serviceProvider;

        private ServiceProviderManager()
        {
        }

        public void SetServiceProvider(ServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public ServiceProvider GetServiceProvider()
        {
            return this._serviceProvider;
        }

        public static ServiceProviderManager GetInstance()
        {
            if(Instance == null)
            {
                Instance = new ServiceProviderManager();
            }

            return Instance;
        }


    }
}
