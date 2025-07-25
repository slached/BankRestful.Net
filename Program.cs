using HangiKredi.Consumer;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("bank_queue", e =>
    {
        // bind the consumer to the endpoint
        e.Consumer<BankConsumer>();
    });
});

// Start the bus
await busControl.StartAsync();


try { 
    Console.WriteLine("Bus started. Press any key to exit...");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    // Stop the bus
    await busControl.StopAsync();
}