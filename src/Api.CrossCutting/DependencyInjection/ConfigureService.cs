using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IPessoaService, PessoaService>();
            serviceCollection.AddTransient<IPlanoService, PlanoService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }

    }
}