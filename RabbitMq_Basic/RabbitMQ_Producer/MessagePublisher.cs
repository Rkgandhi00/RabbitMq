using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProducer
{
    public class MessagePublisher
    {
        public void PublishMessage()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare("letterbox",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                    var message = ConstructMessage();
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish("", "letterbox", null, body);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object ConstructMessage() => new { Name = "Producer", Message = "Hello!" };
    }
}
