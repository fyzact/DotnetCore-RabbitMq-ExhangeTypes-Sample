using System;
using RabbitMQ.Client;
using RabbitMQ.Producer.Helper;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer.Exchanges.Topic
{
    public class TopicMessage : ISendMessage
    {
        public string Message1 => "First Topic Message";
        public string  Message2=>"Second Topic Message";
         public string  Message3=>"Third Topic Message";
       public void SendMessage()
        {
          var  connection = RabbitHelper.GetConnection;
          var channel=connection.CreateModel();
       
         // First message sent by using ROUTING_KEY_1
         channel.BasicPublish(TopicExchange.EXCHANGE_NAME, TopicExchange.ROUTING_KEY_1, null, Message1.GetBytes());
         Console.Write(" Message Sent '" + Message1 + "'");
  
         // Second message sent by using ROUTING_KEY_2
         channel.BasicPublish(TopicExchange.EXCHANGE_NAME, TopicExchange.ROUTING_KEY_2, null, Message2.GetBytes());
         Console.Write(" Message Sent '" + Message2 + "'");
  
         // Third message sent by using ROUTING_KEY_3
         channel.BasicPublish(TopicExchange.EXCHANGE_NAME, TopicExchange.ROUTING_KEY_3, null, Message3.GetBytes());
         Console.Write(" Message Sent '" + Message3 + "'");
        }
       
    }



}
