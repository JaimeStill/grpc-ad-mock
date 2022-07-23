using Grpc.Net.Client;

namespace Identity.Client;
public class IdentityClient : IDisposable
{
    readonly GrpcChannel channel;
    readonly Auth.AuthClient client;

    public IdentityClient(string address)
    {
        channel = GrpcChannel.ForAddress(address);
        client = new Auth.AuthClient(channel);
    }

    public async Task<UserList> GetDomainUsers() =>
        await client.GetDomainUsersAsync(new Empty());

    public async Task<UserList> FindDomainUsers(string search) =>
        await client.FindDomainUsersAsync(new String { Value = search });

    public async Task<User> GetUser(string samAccountName) =>
        await client.GetUserAsync(new String { Value = samAccountName });

    public async Task<User> GetUserByGuid(string guid) =>
        await client.GetUserByGuidAsync(new String { Value = guid });

    public void Dispose()
    {
        channel.Dispose();
        GC.SuppressFinalize(this);
    }
}