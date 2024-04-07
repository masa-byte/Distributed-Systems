using GrpcServer;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcServer.Services
{
    public class FishPondService : FishPond.FishPondBase
    {

        public override async Task<MultiPondData> GetAllData(Empty request, ServerCallContext context)
        {
            try
            {
                return await Task.FromResult(new MultiPondData { });
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }
    }
}
