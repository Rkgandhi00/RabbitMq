using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ_Consumer
{
    public class MessageReceiver
    {
        public void ConsumeMessage()
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
                    channel.QueueDeclare(queue: "letterbox",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Message: " + message);
                    };

                    channel.BasicConsume("letterbox", true, consumer);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
