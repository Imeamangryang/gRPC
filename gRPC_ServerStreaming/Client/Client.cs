using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using Grpc.Core;

using var channel = GrpcChannel.ForAddress("https://localhost:7209");
var client = new serverstreaming.serverstreamingClient(channel);
using var call = client.GetServerResponse(new Number { Value = 1 });

while (await call.ResponseStream.MoveNext())
{
    Console.WriteLine("Server said :  " + call.ResponseStream.Current.Message_);
    // "Greeting: Hello World" is written multiple times
}