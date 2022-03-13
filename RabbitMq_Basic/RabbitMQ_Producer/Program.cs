using System;

namespace RabbitMQProducer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var publisher = new MessagePublisher();
            publisher.PublishMessage();
        }
    }
}
