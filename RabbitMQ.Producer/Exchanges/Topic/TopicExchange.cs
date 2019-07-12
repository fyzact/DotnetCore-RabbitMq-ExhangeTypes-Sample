using RabbitMQ.Client;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer
{
    public class TopicExchange:IExchangeFactory{
        public static string EXCHANGE_NAME = "topic-exchange";
 public static string QUEUE_NAME_1 = "topic-queue-1";
 public static string QUEUE_NAME_2 = "topic-queue-2";
 public static string QUEUE_NAME_3 = "topic-queue-3";
 
 public static string ROUTING_PATTERN_1 = "asia.china.*";
 public static string ROUTING_PATTERN_2 = "asia.china.#";
 public static string ROUTING_PATTERN_3 = "asia.*.*";
  
 public static string ROUTING_KEY_1 = "asia.china.nanjing";
 public static string ROUTING_KEY_2 = "asia.china";
 public static string ROUTING_KEY_3 = "asia.china.beijing";

        public void CreateExChangeAndQueue()
        {
              var  connection = RabbitHelper.GetConnection;
          var channel=connection.CreateModel();
         channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Headers, true);

          channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
         channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME,ROUTING_PATTERN_1);

            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
         channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME,ROUTING_PATTERN_2);

            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
         channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME,ROUTING_PATTERN_3);
        }
    }



}
