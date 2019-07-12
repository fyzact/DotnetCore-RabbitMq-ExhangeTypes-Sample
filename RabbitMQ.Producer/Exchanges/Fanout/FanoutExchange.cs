using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    public class FanoutExchange : IExchangeFactory
    {
        public static string EXCHANGE_NAME = "fanout-exchange";
        public static string QUEUE_NAME_1 = "fanout-queue-1";
        public static string QUEUE_NAME_2 = "fanout-queue-2";
        public static string QUEUE_NAME_3 = "fanout-queue-3";

        public static string ROUTING_KEY = "";
        public void CreateExChangeAndQueue()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout, true);

            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY);
        }
    }
}
