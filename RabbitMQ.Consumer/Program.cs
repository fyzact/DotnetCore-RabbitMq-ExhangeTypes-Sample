using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CreateConsumer("direct-queue-1");
            CreateConsumer("direct-queue-2");
            CreateConsumer("direct-queue-3");

            CreateConsumer("header-queue-1");
            CreateConsumer("header-queue-2");
            CreateConsumer("header-queue-3");

            CreateConsumer("fanout-queue-1");
            CreateConsumer("fanout-queue-2");
            CreateConsumer("fanout-queue-3");

            CreateConsumer("topic-queue-1");
            CreateConsumer("topic-queue-2");
            CreateConsumer("topic-queue-3");
            Console.ReadKey();
        }

        static void CreateConsumer(string queue){
              var connection = RabbitHelper.GetConnection;
        var channel = connection.CreateModel();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body;
            var message = body.GetString();
            Console.WriteLine( $"{queue} Received {body.GetString()}", message);
        };
        channel.BasicConsume(queue: queue,
                             autoAck: true,
                             consumer: consumer);
        }

    }
 
}

public static class StringExtentions
{
    public static byte[] GetBytes(this string value)
    {
        return System.Text.Encoding.ASCII.GetBytes(value);
    }

    public static string GetString(this byte[] value)
    {
        return System.Text.Encoding.UTF8.GetString(value);
    }
}

public class RabbitHelper
{
    static Lazy<IConnection> _connection = new Lazy<IConnection>(CreateConnection);
    public static IConnection GetConnection => _connection.Value;
    private static IConnection CreateConnection()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        return connection;
    }
}
