using MassTransit;
using Newtonsoft.Json;
using RabbitMQMassTransit.Domain.Message;

namespace RabbitMQMassTransit.API.Consumers
{
    public class QueueFilaConsumer : IConsumer<EnviarFilaMessage>
    {
        private readonly ILogger<QueueFilaConsumer> _logger;
        public QueueFilaConsumer(ILogger<QueueFilaConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<EnviarFilaMessage> context)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(new { Title = "Fila Consumida fila-enviar-mensagem", context.Message }));

            return Task.CompletedTask;
        }

        public class QueueFilaDefinition : ConsumerDefinition<QueueFilaConsumer>
        {
            public QueueFilaDefinition()
            {
                base.EndpointName = "fila-enviar-mensagem";
            }

            protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<QueueFilaConsumer> consumerConfigurator)
            {
                endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            }
        }
    }
}
