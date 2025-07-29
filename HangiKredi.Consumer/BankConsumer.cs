using hangi_kredi_restful.Common;
using hangi_kredi_restful.Models;
using MassTransit;
using System.Text.Json;

namespace HangiKredi.Consumer
{
    public class BankConsumer : IConsumer<ApiResponse<BankReturnType>>
    {
        public async Task Consume(ConsumeContext<ApiResponse<BankReturnType>> context)
        {

            var msg = JsonSerializer.Serialize(context.Message);

            Console.WriteLine("Bank get event consumed successfully." + msg);

            await Task.CompletedTask;
        }

    }
}
