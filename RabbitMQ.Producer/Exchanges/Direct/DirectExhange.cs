using RabbitMQ.Client;
using RabbitMQ.Producer.Helper;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer.Exchanges.Direct
{
    public class DirectExhange : IExchangeFactory
    {
        public static string EXCHANGE_NAME = "direct-exchange";
        public static string QUEUE_NAME_1 = "direct-queue-1";
        public static string QUEUE_NAME_2 = "direct-queue-2";
        public static string QUEUE_NAME_3 = "direct-queue-3";
        public static string ROUTING_KEY_1 = "direct-key-1";
        public static string ROUTING_KEY_2 = "direct-key-2";
        public static string ROUTING_KEY_3 = "direct-key-3";
        public void CreateExChangeAndQueue()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, true);
            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY_1);

            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY_2);

            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY_3);
        }
    }

}
