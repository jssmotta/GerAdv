#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GraphEndpoints
{
    public static IEndpointRouteBuilder MapGraphEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Graph").WithTags("Graph").RequireAuthorization();
        MapGraphRoutes(group);
        return app;
    }

    private static void MapGraphRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGraphService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Graph_GetAll").WithDisplayName("Get All Graph");
        group.MapPost("/Filter", async (Filters.FilterGraph filtro, string uri, IGraphService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Graph_Filter").WithDisplayName("Filter Graph");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGraphService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Graph found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Graph_GetById").WithDisplayName("Get Graph By Id");
        group.MapPost("/AddAndUpdate", async (Models.Graph regGraph, string uri, IGraphValidation validation, IGraphWriter writer, IGraphService service) =>
        {
            var result = await service.AddAndUpdate(regGraph, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Graph_AddAndUpdate").WithDisplayName("Add or Update Graph");
        group.MapDelete("/Delete", async (int id, string uri, IGraphValidation validation, IGraphWriter writer, IGraphService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Graph_Delete").WithDisplayName("Delete Graph");
    }
}