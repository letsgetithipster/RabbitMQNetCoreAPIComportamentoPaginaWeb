using Microsoft.Extensions.Configuration;
using MqConsumer.Business;
using MqConsumer.Models;
using MqConsumer.Repositorio;
using System.IO;

namespace MqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);            

            IConfigurationRoot configuration = builder.Build();

            Aplicacao app = new Aplicacao(
                new ComportamentoRepository(
                    new ComportamentoContext(
                        configuration.GetConnectionString("DefaultConnection"))));
            app.Iniciar();
        }
    }
}
