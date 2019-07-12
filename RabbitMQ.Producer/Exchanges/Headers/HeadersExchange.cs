
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer
{
    public class HeadersExchange : IExchangeFactory
    {
        public static string EXCHANGE_NAME = "header-exchange";
        public static string QUEUE_NAME_1 = "header-queue-1";
        public static string QUEUE_NAME_2 = "header-queue-2";
        public static string QUEUE_NAME_3 = "header-queue-3";
        public void CreateExChangeAndQueue()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Headers, true);
            var map1 = new Dictionary<string, object>();
            map1.Add("x-match", "any");
            map1.Add("First", "A");
            map1.Add("Fourth", "D");
             // Firs Queue
            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, "", map1);

            var map2 = new Dictionary<string, object>();
            map2.Add("x-match", "any");
            map2.Add("Fourth", "D");
            map2.Add("Third", "C");
            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, "", map2);

            var map3 = new Dictionary<string, object>();
            map3.Add("x-match", "all");
            map3.Add("First", "A");
            map3.Add("Third", "C");
            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, "", map3);
        }
    }

}
