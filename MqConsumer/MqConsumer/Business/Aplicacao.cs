using MqConsumer.Models;
using MqConsumer.Repositorio;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MqConsumer.Business
{
    public class Aplicacao
    {
        private const string nomeQueue = "ComportamentosQ";
        private readonly IComportamentoRepository _repository;

        public Aplicacao(IComportamentoRepository repository)
        {
            this._repository = repository;
        }

        public void Iniciar()
        {
            try
            {
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

                        var consumer = new EventingBasicConsumer(chanel);

                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;                           

                            Comportamento comportamento = ComportamentoDeserializado(body);
                            GravaComportamento(comportamento);

                            Console.WriteLine($"{DateTime.Now} - Comportamento recebido.");
                        };

                        chanel.BasicConsume(
                            queue: nomeQueue,
                            autoAck: true,
                            consumer: consumer
                            );

                        Console.WriteLine($"{DateTime.Now} - Consumer funcionando.");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void GravaComportamento(Comportamento comportamento)
        {
            _repository.Add(comportamento);
            CsvWriter.Add(comportamento);
        }

        private Comportamento ComportamentoDeserializado(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);

            return JsonConvert.DeserializeObject<Comportamento>(message);
        }
    }
}
