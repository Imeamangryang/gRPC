using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using Grpc.Core;

using var channel = GrpcChannel.ForAddress("https://localhost:7203");
var client = new ClientStreaming.ClientStreamingClient(channel);
using var call = client.GetServerResponse();

while (true)
{
    var result = Console.ReadLine();
    if (string.IsNullOrEmpty(result))
    {
        break;
    }
    await call.RequestStream.WriteAsync(new Message { Name = result });
}
    await call.RequestStream.CompleteAsync();

var response = await call;
Console.WriteLine("--Clientstreaming End--");