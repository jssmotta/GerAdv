#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutputEngineEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutputEngineEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutputEngine").WithTags("ProcessOutputEngine").RequireAuthorization();
        MapProcessOutputEngineRoutes(group);
        return app;
    }

    private static void MapProcessOutputEngineRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputEngineService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetAll").WithDisplayName("Get All ProcessOutputEngine");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputEngine filtro, string uri, IProcessOutputEngineService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_Filter").WithDisplayName("Filter ProcessOutputEngine");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputEngineService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutputEngine found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetById").WithDisplayName("Get ProcessOutputEngine By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutputEngine? filtro, string uri, IProcessOutputEngineService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetListN").WithDisplayName("Get ProcessOutputEngine List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutputEngine regProcessOutputEngine, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            var result = await service.AddAndUpdate(regProcessOutputEngine, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputEngine");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_Delete").WithDisplayName("Delete ProcessOutputEngine");
    }
}