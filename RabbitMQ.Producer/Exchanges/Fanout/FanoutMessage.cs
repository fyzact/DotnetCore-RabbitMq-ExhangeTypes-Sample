using System;
using RabbitMQ.Client;
using RabbitMQ.Producer.Helper;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer.Exchanges.Fanout
{
    public class FanoutMessage : ISendMessage
    {
        public string Message1 => "First Fanout Message";
        public string Message2 => "Second Fanout Message";
        public string Message3 => "Third Fanout Message";

        public void SendMessage()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            
            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message1.GetBytes());
            Console.Write(" Message Sent '" + Message1 + "'");

            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message2.GetBytes());
            Console.Write(" Message Sent '" + Message2 + "'");

            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message3.GetBytes());
            Console.Write(" Message Sent '" + Message3 + "'");
        }
    }
}
