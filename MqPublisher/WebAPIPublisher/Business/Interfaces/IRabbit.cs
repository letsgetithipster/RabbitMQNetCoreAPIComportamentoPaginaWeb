using MqPublisher;

namespace WebAPIPublisher.Business
{
    public interface IRabbit
    {
        void InsereEvento(Comportamento comportamento);
    }
}