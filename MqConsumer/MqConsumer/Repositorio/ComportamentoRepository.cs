using MqConsumer.Models;

namespace MqConsumer.Repositorio
{
    public class ComportamentoRepository : IComportamentoRepository
    {
        private readonly ComportamentoContext _contexto;

        public ComportamentoRepository(ComportamentoContext context)
        {
            this._contexto = context;
        }

        public void Add(Comportamento comportamento)
        {
            _contexto.Comportamento.Add(comportamento);
            _contexto.SaveChanges();
        }
    }
}
