namespace Identity.Core;
public class AdMock
{
    public static Task<List<AdUser>> GetDomainUsers() =>
        Task.Run(() =>
            Users
                .OrderBy(x => x.Surname)
                .ToList()
        );

    public static Task<List<AdUser>> FindDomainUsers(string search) =>
        Task.Run(() =>
        {
            search = search.ToLower();

            return Users
                .Where(x =>
                    x.SamAccountName.ToLower().Contains(search)
                    || x.UserPrincipalName.ToLower().Contains(search)
                    || x.DisplayName.ToLower().Contains(search)
                )
                .OrderBy(x => x.Surname)
                .ToList();
        });

    public static Task<AdUser> GetUser(string samAccountName) =>
        Task.Run(() =>
            Users.FirstOrDefault(x =>
                x.SamAccountName.ToLower().Equals(samAccountName.ToLower())
            )
        );

    public static Task<AdUser> GetUser(Guid guid) =>
        Task.Run(() =>
            Users.FirstOrDefault(x => x.Guid.Equals(guid))
        );

    static readonly string baseDn = "CN=Users,DC=Mock,DC=Net";

    static readonly IQueryable<AdUser> Users = new List<AdUser>
    {
        new AdUser
        {
            Guid = Guid.Parse("c40bcced-28cd-406e-84c0-2d1d446b9a63"),
            DisplayName = "Graham, Leanne",
            DistinguishedName = $"CN=lgraham,{baseDn}",
            EmailAddress = "lgraham@mock.net",
            Enabled = true,
            GivenName = "Leanne",
            SamAccountName = "lgraham",
            Surname = "Graham",
            UserPrincipalName = "lgraham@mock.net",
            VoiceTelephoneNumber = "555.555.0001"
        },
        new AdUser
        {
            Guid = Guid.Parse("f16f6b21-c2d9-4dcf-a8d2-96906ca49872"),
            DisplayName = "Howell, Ervin",
            DistinguishedName = $"CN=ehowell,{baseDn}",
            EmailAddress = "ehowell@mock.net",
            Enabled = true,
            GivenName = "Ervin",
            SamAccountName = "ehowell",
            Surname = "Howell",
            UserPrincipalName = "ehowell@mock.net",
            VoiceTelephoneNumber = "555.555.0002"
        },
        new AdUser
        {
            Guid = Guid.Parse("f6eaba45-1b3e-494e-95e7-89894c6c7c5e"),
            DisplayName = "Bauch, Clementine",
            DistinguishedName = $"CN=cbauch,{baseDn}",
            EmailAddress = "cbauch@mock.net",
            Enabled = true,
            GivenName = "Clementine",
            SamAccountName="cbauch",
            Surname = "Bauch",
            UserPrincipalName = "cbauch@mock.net",
            VoiceTelephoneNumber = "555.555.0003"
        },
        new AdUser
        {
            Guid = Guid.Parse("f6d6fe1d-ae07-4e33-9ef5-f377e79f3a8b"),
            DisplayName = "Lebsack, Patricia",
            DistinguishedName = $"CN=plebsack,{baseDn}",
            EmailAddress = "plebsack@mock.net",
            Enabled = true,
            GivenName = "Patricia",
            SamAccountName = "plebsack",
            Surname = "Lebsack",
            UserPrincipalName = "plebsack@mock.net",
            VoiceTelephoneNumber = "555.555.0004"
        },
        new AdUser
        {
            Guid = Guid.Parse("710f21e9-ef86-45f5-95cc-339e73cb8e8a"),
            DisplayName = "Dietrich, Chelsey",
            DistinguishedName = $"CN=cdietrich,{baseDn}",
            EmailAddress = "cdietrch@mock.net",
            Enabled = true,
            GivenName = "Chelsey",
            SamAccountName = "cdietrich",
            Surname = "Dietrich",
            UserPrincipalName = "cdietrich@mock.net",
            VoiceTelephoneNumber = "555.555.0005"
        },
        new AdUser
        {
            Guid = Guid.Parse("854c25c1-d0dc-454a-9152-3db2c246f591"),
            DisplayName = "Schulist, Dennis",
            DistinguishedName = $"CN=dschulist,{baseDn}",
            EmailAddress = "dschulist@mock.net",
            Enabled = true,
            GivenName = "Dennis",
            SamAccountName = "dschulist",
            Surname = "Schulist",
            UserPrincipalName = "dschulist@mock.net",
            VoiceTelephoneNumber = "555.555.0006"
        },
        new AdUser
        {
            Guid = Guid.Parse("0f50dc7d-7ff9-4f18-be91-add0665e8078"),
            DisplayName = "Weissnat, Kurtis",
            DistinguishedName = $"CN=kweissnat,{baseDn}",
            EmailAddress = "kweissnat@mock.net",
            Enabled = true,
            GivenName = "Kurtis",
            SamAccountName = "kweissnat",
            Surname = "Weissnat",
            UserPrincipalName = "kweissnat@mock.net",
            VoiceTelephoneNumber = "555.555.0007"
        }
    }.AsQueryable();
}