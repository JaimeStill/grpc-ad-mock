using Identity.Client;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    readonly IdentityClient client;
    
    public IdentityController(IdentityClient client)
    {
        this.client = client;
    }

    [HttpGet("[action]")]
    public User GetCurrentUser() => Request.HttpContext.Items["AdUser"] as User;

    [HttpGet("[action]")]
    public async Task<UserList> GetDomainUsers() => await client.GetDomainUsers();
}