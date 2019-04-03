using MqPublisher;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebAPIPublisher.Business
{
    public class Rabbit : IRabbit
    {
        private const string nomeQueue = "ComportamentosQ";

        public void InsereEvento(Comportamento comportamento)
        {
            string message = JsonConvert.SerializeObject(comportamento);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    chanel.QueueDeclare(
                        queue: nomeQueue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    var body = Encoding.UTF8.GetBytes(message);

                    chanel.BasicPublish(
                        exchange: "",
                        routingKey: nomeQueue,
                        basicProperties: null,
                        body: body
                        );
                }
            }
        }
    }
}
