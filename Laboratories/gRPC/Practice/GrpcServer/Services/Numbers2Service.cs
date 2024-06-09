using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcServer.Services
{
    public class Numbers2Service: Numbers2.Numbers2Base
    {
        static double acc = 1;

        public override Task<Empty> AvgValue(Number request, ServerCallContext context)
        {
            int sum = 0;
            int count = 0;

            for (int i = (int)request.Value; i > 0; i--)
            {
                sum += i;
                count++;
            }

            double avg = (double)sum / count;
            acc += avg;

            return Task.FromResult(new Empty());
        }

        public override async Task Calculate(IAsyncStreamReader<Number> requestStream, IServerStreamWriter<Number> responseStream, ServerCallContext context)
        {
            int count = 1;

            while (await requestStream.MoveNext())
            {
                var el = (Number)requestStream.Current;

                if (count % 3 == 0)
                {
                    await responseStream.WriteAsync(new Number()
                    {
                        Value = el.Value * acc
                    });
                }
                else
                {
                    await responseStream.WriteAsync(new Number()
                    {
                        Value = el.Value - acc
                    });
                }
                count++;
            }
        }

        public override Task<Number> GetAccumulator(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new Number() { Value = acc });
        }
    }
}
