using MassTransit;
using RabbitMQMassTransit.Domain.EnvironmentConfiguration;
using System.Reflection;

namespace RabbitMQMassTransit.API.Configuration
{
    public static class MasstransitConfiguration
    {
        public static void AddMassTransitConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                var entryAssembly = Assembly.GetEntryAssembly();
                x.AddConsumers(entryAssembly);

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    var conection = configuration.GetSection("RabbitMQConfiguration").Get<RabbitMQConfiguration>();

                    cfg.Host(conection.Host, h =>
                    {
                        h.Username(conection.User);
                        h.Password(conection.Password);
                    });

                    cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("fila", false));
                    cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
                });
            });
        }
    }
}
