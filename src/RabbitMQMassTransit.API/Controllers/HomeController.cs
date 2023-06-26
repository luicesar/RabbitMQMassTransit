using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQMassTransit.Domain.Message;

namespace RabbitMQMassTransit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPublishEndpoint publisher, ILogger<HomeController> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        [HttpPost("fila-enviar-mensagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] EnviarFilaMessage msg)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(new { Title = "Enviando msg fila-enviar-mensagem", msg }));
            await _publisher.Publish(msg);
            return Ok();
        }

    }
}
