using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Producer.Interfaces;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var exhangeFactory=CreateExchange(ExchangeType.Headers);
            exhangeFactory.CreateExChangeAndQueue();
            var producer=CreateSendMessage(ExchangeType.Headers);
            producer.SendMessage();
        }



        public  static ISendMessage CreateSendMessage(string exchangeType){

                switch (exchangeType)
                {
                   case ExchangeType.Direct:
                    return new DirectMessage();
                      case ExchangeType.Headers:
                    return new HeadersMessage();
                       case ExchangeType.Topic:
                    return new TopicMessage();
                      case ExchangeType.Fanout:
                    return new FanoutMessage();
                    default:
                    throw new  Exception("there is no properly exchange type");
                }
        }

            public  static IExchangeFactory CreateExchange(string exchangeType){

                switch (exchangeType)
                {
                   case ExchangeType.Direct:
                    return new DirectExhange();
                      case ExchangeType.Headers:
                    return new HeadersExchange();
                       case ExchangeType.Topic:
                    return new TopicExchange();
                      case ExchangeType.Fanout:
                    return new FanoutExchange();
                    default:
                    throw new  Exception("there is no properly exchange type");
                }
        }
    }

}
