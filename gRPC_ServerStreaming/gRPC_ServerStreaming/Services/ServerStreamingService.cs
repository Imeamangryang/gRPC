using Grpc.Core;
using gRPC_ServerStreaming;

namespace gRPC_ServerStreaming.Services
{
    public class ServerStreamingService : serverstreaming.serverstreamingBase
    {
        private readonly ILogger<ServerStreamingService> _logger;
        public ServerStreamingService(ILogger<ServerStreamingService> logger)
        {
            _logger = logger;
        }

        public override async Task GetServerResponse(
            Number request, 
            IServerStreamWriter<Message> responseStream, 
            ServerCallContext context)
        {
            while(!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new Message
                {
                    Message_ = "ServerStreamingTest"
                });
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
