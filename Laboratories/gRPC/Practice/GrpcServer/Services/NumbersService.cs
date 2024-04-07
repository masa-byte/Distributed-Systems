using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcServer.Services
{
    public class NumbersService : Numbers.NumbersBase
    {
        public override async Task<Empty> AverageValueForData(IAsyncStreamReader<Data> requestStream, ServerCallContext context)
        {
            int sum = 0;
            int count = 0;

            await foreach (var data in requestStream.ReadAllAsync())
            {
                sum += data.Value;
                count++;
                AccDB.Instance.Acc = sum / count;
                Console.WriteLine($"Average: {AccDB.Instance.Acc}");
            }

            return await Task.FromResult(new Empty());
        }

        public override async Task AddOrMultiplyData(IAsyncStreamReader<Data> requestStream, IServerStreamWriter<Data> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var number = requestStream.Current.Value;
                if (number % 2 == 0)
                {
                    await responseStream.WriteAsync(new Data { Value = number + AccDB.Instance.Acc });
                }
                else
                {
                    await responseStream.WriteAsync(new Data { Value = number * AccDB.Instance.Acc });
                }
            }
        }

        public override async Task<Data> GetAccumulator(Empty request, ServerCallContext context)
        {
            Console.WriteLine($"Accumulator: {AccDB.Instance.Acc}"); 
            return await Task.FromResult(new Data { Value = AccDB.Instance.Acc });
        }
    }
}
