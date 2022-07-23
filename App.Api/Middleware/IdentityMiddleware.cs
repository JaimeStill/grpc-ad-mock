using Identity.Client;

namespace App.Api.Middleware;
public class IdentityMiddleware
{
    private readonly RequestDelegate next;

    public IdentityMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context, IdentityClient client)
    {
        User user = await client.GetUser("ehowell");
        context.Items.Add("AdUser", user);

        await next(context);
    }
}

public static class IdentityExtensions
{
    public static IApplicationBuilder UseIdentity(this IApplicationBuilder builder) =>
        builder.UseMiddleware<IdentityMiddleware>();
}