using Grpc.Core;
using Identity.Core;

namespace Identity.Server.Services;

public class AuthService : Auth.AuthBase
{
    static User CastToUser(AdUser user) => new()
    {
        DisplayName = user.DisplayName,
        DistinguishedName = user.DistinguishedName,
        EmailAddress = user.EmailAddress,
        Enabled = user.Enabled,
        GivenName = user.GivenName,
        Guid = user.Guid.ToString(),
        SamAccountName = user.SamAccountName,
        Surname = user.Surname,
        UserPrincipalName = user.UserPrincipalName,
        VoiceTelephoneNumber = user.VoiceTelephoneNumber
    };

    public override async Task<UserList> GetDomainUsers(Empty request, ServerCallContext context)
    {
        List<AdUser> users = await AdMock.GetDomainUsers();
        UserList reply = new();
        reply.Users.Add(users.Select(x => CastToUser(x)));
        return reply;
    }

    public override async Task<UserList> FindDomainUsers(String request, ServerCallContext context)
    {
        List<AdUser> users = await AdMock.FindDomainUsers(request.Value);
        UserList reply = new();
        reply.Users.Add(users.Select(x => CastToUser(x)));
        return reply;
    }

    public override async Task<User> GetUser(String request, ServerCallContext context) =>
        CastToUser(await AdMock.GetUser(request.Value));

    public override async Task<User> GetUserByGuid(String request, ServerCallContext context) =>
        CastToUser(await AdMock.GetUser(Guid.Parse(request.Value)));
}