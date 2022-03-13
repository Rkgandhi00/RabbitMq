using RabbitMQ_Consumer;
using System;

namespace RbbitMQ_Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var consumer = new MessageReceiver();
            consumer.ConsumeMessage();
        }
    }
}
