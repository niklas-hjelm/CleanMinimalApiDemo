using CleanMinimalApiDemo.API.Extensions.EndpointGroups;

namespace CleanMinimalApiDemo.API.Extensions;

public static class WebApplicationEndpointExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGroup("/person").MapPersonGroup();
        app.MapGroup("/pet").MapPetGroup();
        
        return app;
    }
}