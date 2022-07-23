using Identity.Client;

IdentityClient client = new("https://localhost:7271");

var getReply = await client.GetDomainUsers();

foreach (var user in getReply.Users)
    Console.WriteLine($"GetDomainUsers: {user.UserPrincipalName}");

var findReply = await client.FindDomainUsers("le");

foreach (var user in findReply.Users)
    Console.WriteLine($"FindDomainUsers: {user.UserPrincipalName}");

var userReply = await client.GetUser(getReply.Users.First().SamAccountName);

Console.WriteLine($"GetUser: {userReply.UserPrincipalName}");

var guidReply = await client.GetUserByGuid(getReply.Users.First().Guid);

Console.WriteLine($"GetUserByGuid: {guidReply.UserPrincipalName}");