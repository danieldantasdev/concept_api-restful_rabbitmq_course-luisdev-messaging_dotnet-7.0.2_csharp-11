using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Messaging.RabbitMqClient.Models;

const string EXCHANGE = "curso-rabbitmq";
const string ROUTING_KEY = "hr.person-created";

var person = new Person("Daniel Dantas", "123.456.789-10", new DateTime(1992, 1, 1));

//abrindo a conexão e o canal
var connectionFactory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = connectionFactory.CreateConnection("curso-rabbitmq");
var channel = connection.CreateModel();

//Precisamos serializar (transformar em string) e obter os bytes dos dados para trafegar e publicar a mensagem
var json = JsonSerializer.Serialize(person);
var byteArray = Encoding.UTF8.GetBytes(json);

channel.BasicPublish(EXCHANGE, ROUTING_KEY, null, byteArray);
Console.WriteLine($"Message published: {json}");

//Consumindo a mensagem
var consumerChannel = connection.CreateModel();
var consumer = new EventingBasicConsumer(consumerChannel);

consumer.Received += (sender, eventArgs) =>
{
    var contentArray = eventArgs.Body.ToArray();
    var contentString = Encoding.UTF8.GetString(contentArray);

    var message = JsonSerializer.Deserialize<Person>(contentString);

    Console.WriteLine($"Message received: {contentString}");

    consumerChannel.BasicAck(eventArgs.DeliveryTag, false);
};

consumerChannel.BasicConsume("person-created", false, consumer);

Console.ReadLine();