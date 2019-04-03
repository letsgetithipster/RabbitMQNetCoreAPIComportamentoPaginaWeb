using Microsoft.AspNetCore.Mvc;
using MqPublisher;
using WebAPIPublisher.Business;

namespace WebAPIPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComportamentoController : ControllerBase
    {
        private readonly IRabbit _rabbit;

        public ComportamentoController(IRabbit rabbit)
        {
            this._rabbit = rabbit;
        }

        // POST: api/Comportamento
        [HttpPost]
        public IActionResult Create([FromBody] Comportamento comportamento)
        {
            if (comportamento == null)
                return BadRequest();

            _rabbit.InsereEvento(comportamento);

            return new NoContentResult();
        }
    }
}
