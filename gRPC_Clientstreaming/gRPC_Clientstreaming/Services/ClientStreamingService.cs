using Grpc.Core;
using gRPC_Clientstreaming;

namespace gRPC_Clientstreaming.Services
{
    public class ClientStreamingService : ClientStreaming.ClientStreamingBase
    {
        private readonly ILogger<ClientStreamingService> _logger;

        public ClientStreamingService(ILogger<ClientStreamingService> logger)
        {
            _logger = logger;
        }

        public override async Task<Reply> GetServerResponse(
            IAsyncStreamReader<Message> requestStream, 
            ServerCallContext context)
        {

            while (await requestStream.MoveNext())
            {
                var message = requestStream.Current;
                Console.WriteLine("The Client said : ");
                Console.WriteLine(message.Name);
            }
            return new Reply();
        }
    }
}
