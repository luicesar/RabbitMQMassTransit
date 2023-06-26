namespace RabbitMQMassTransit.Domain.Message
{
    public record EnviarFilaMessage
    {
        public long Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
