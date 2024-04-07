using Grpc.Core;

namespace GrpcServer.Services
{
    public class UserService : Users.UsersBase
    {
        public override Task<User> GetUserById(UserId request, ServerCallContext context)
        {
            if (!UsersDB.Instance.DB.ContainsKey(int.Parse(request.Id)))
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            else
                return Task.FromResult(UsersDB.Instance.DB[int.Parse(request.Id)]);
        }

        public override Task<Message> AddNewUser(User request, ServerCallContext context)
        {
            if (UsersDB.Instance.DB.ContainsKey(int.Parse(request.Id)))
            {
                throw new RpcException(new Status(StatusCode.AlreadyExists, "User already exists"));
            }
            else
            {
                UsersDB.Instance.DB.Add(int.Parse(request.Id), request);
                return Task.FromResult(new Message { Text = $"User with id {request.Id} successfully added" });
            }
        }

        public override Task<Message> UpdateUser(User request, ServerCallContext context)
        {
            if (!UsersDB.Instance.DB.ContainsKey(int.Parse(request.Id)))
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            else
            {
                UsersDB.Instance.DB[int.Parse(request.Id)] = request;
                return Task.FromResult(new Message { Text = $"User with id {request.Id} successfully updated" });
            }
        }

        public override Task<Message> DeleteUser(UserId request, ServerCallContext context)
        {
            if (!UsersDB.Instance.DB.ContainsKey(int.Parse(request.Id)))
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            else
            {
                UsersDB.Instance.DB.Remove(int.Parse(request.Id));
                return Task.FromResult(new Message { Text = $"User with id {request.Id} successfully deleted" });
            }
        }

        public override async Task GetUsersFromTo(UserIds request, IServerStreamWriter<User> responseStream, ServerCallContext context)
        {
            var users = UsersDB.Instance.DB.OrderBy(x => x.Key).Where(x => x.Key >= int.Parse(request.From) && x.Key <= int.Parse(request.To));

            foreach (var user in users)
            {
                await responseStream.WriteAsync(user.Value);
            }
        }

        public override async Task DeleteUsers(IAsyncStreamReader<UserId> requestStream, IServerStreamWriter<Message> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var userId = requestStream.Current;
                if (!UsersDB.Instance.DB.ContainsKey(int.Parse(userId.Id)))
                {
                    await responseStream.WriteAsync(new Message { Text = $"User with id {userId.Id} not found" });
                }
                else
                {
                    UsersDB.Instance.DB.Remove(int.Parse(userId.Id));
                    await responseStream.WriteAsync(new Message { Text = $"User with id {userId.Id} successfully deleted" });
                }
            }
        }
    }
}
