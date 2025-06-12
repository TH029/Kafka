using Confluent.Kafka;

class Program
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        try
        {
            for (int i = 0; i < 10; i++)
            {
                var result = await producer.ProduceAsync(
                    "demo-topic",
                    new Message<Null, string> { Value = $"¡Hola desde  envio  thais  se  logro {i}" });

                Console.WriteLine($"Mensaje {i} enviado a: {result.TopicPartitionOffset}");
            }
        }
        catch (ProduceException<Null, string> ex)
        {
            Console.WriteLine($"Error al enviar: {ex.Error.Reason}");
        }
    }
}
