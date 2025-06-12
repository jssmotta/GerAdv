#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutputSourcesEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutputSourcesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutputSources").WithTags("ProcessOutputSources").RequireAuthorization();
        MapProcessOutputSourcesRoutes(group);
        return app;
    }

    private static void MapProcessOutputSourcesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputSourcesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetAll").WithDisplayName("Get All ProcessOutputSources");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputSources filtro, string uri, IProcessOutputSourcesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_Filter").WithDisplayName("Filter ProcessOutputSources");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputSourcesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutputSources found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetById").WithDisplayName("Get ProcessOutputSources By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutputSources? filtro, string uri, IProcessOutputSourcesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetListN").WithDisplayName("Get ProcessOutputSources List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutputSources regProcessOutputSources, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            var result = await service.AddAndUpdate(regProcessOutputSources, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputSources");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_Delete").WithDisplayName("Delete ProcessOutputSources");
    }
}