using CleanMinimalApiDemo.API.Endpoints.Requests;
using MediatR;

namespace CleanMinimalApiDemo.API.Extensions;

public static class MinimalatRExtensions
{
    public static RouteGroupBuilder MedateGet<TRequest>(
        this RouteGroupBuilder builder, 
        string pattern) where TRequest : IHttpRequest
    {
        builder.MapGet(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return builder;
    }

    public static RouteGroupBuilder MedatePost<TRequest>(
        this RouteGroupBuilder builder,
        string pattern) where TRequest : IHttpRequest
    {
        builder.MapPost(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return builder;
    }

    public static RouteGroupBuilder MedatePut<TRequest>(
        this RouteGroupBuilder builder,
        string pattern) where TRequest : IHttpRequest
    {
        builder.MapPut(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return builder;
    }

    public static RouteGroupBuilder MedateDelete<TRequest>(
        this RouteGroupBuilder builder,
        string pattern) where TRequest : IHttpRequest
    {
        builder.MapDelete(pattern,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return builder;
    }
}