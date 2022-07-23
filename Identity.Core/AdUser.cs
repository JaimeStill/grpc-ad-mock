namespace Identity.Core;
public class AdUser
{
    public Guid Guid { get; set; }
    public string DisplayName { get; set; }
    public string DistinguishedName { get; set; }
    public string EmailAddress { get; set; }
    public string GivenName { get; set; }
    public string SamAccountName { get; set; }
    public string Surname { get; set; }
    public string UserPrincipalName { get; set; }
    public string VoiceTelephoneNumber { get; set; }
    public bool Enabled { get; set; }
}