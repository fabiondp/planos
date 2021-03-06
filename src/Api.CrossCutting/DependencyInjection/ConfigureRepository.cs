using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Data.Repository;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        //public IConfiguration Configuration { get; }

        //public ConfigureRepository(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    StaticConfig = configuration;
        //}

        //public static IConfiguration StaticConfig { get; private set; }

        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString){

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IPessoaRepository, PessoaImplementation>();
            serviceCollection.AddScoped<IPlanoRepository, PlanoRepository>();

            //  serviceCollection.AddDbContext<MyContext>(
            //     options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPP;Uid=root;Pwd=mudar@123")
            // );


            //"Server=.\\SQLEXPRESS2017;Database=dbAPP;User Id=sa;Pwd=mudar@123"); ;
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(connectionString)
            );
            
        }
    }
}