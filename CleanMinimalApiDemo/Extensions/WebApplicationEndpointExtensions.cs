using CleanMinimalApiDemo.API.Endpoints.Requests;
using CleanMinimalApiDemo.API.Extensions.EndpointGroups;
using MediatR;

namespace CleanMinimalApiDemo.API.Extensions;

public static class WebApplicationEndpointExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGroup("/person").MapPersonGroup();
        app.MapGroup("/pet").MapPetGroup();

        app.MediatePut<UpdatePersonRequest>("/person/{id}");

        return app;
    }

    public static WebApplication MediatePut<TRequest>(
        this WebApplication app, 
        string pattern) 
        where TRequest : IHttpRequest
    {
        app.MapPut(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) => 
                await mediator.Send(request)
                );
        return app;
    }

    public static WebApplication MediateGet<TRequest>(
        this WebApplication app,
        string pattern)
        where TRequest : IHttpRequest
    {
        app.MapGet(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) =>
                await mediator.Send(request)
        );
        return app;
    }

}