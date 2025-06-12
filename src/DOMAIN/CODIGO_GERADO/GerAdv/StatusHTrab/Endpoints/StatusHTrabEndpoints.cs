#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusHTrabEndpoints
{
    public static IEndpointRouteBuilder MapStatusHTrabEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusHTrab").WithTags("StatusHTrab").RequireAuthorization();
        MapStatusHTrabRoutes(group);
        return app;
    }

    private static void MapStatusHTrabRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusHTrabService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_GetAll").WithDisplayName("Get All StatusHTrab");
        group.MapPost("/Filter", async (Filters.FilterStatusHTrab filtro, string uri, IStatusHTrabService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_Filter").WithDisplayName("Filter StatusHTrab");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusHTrabService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusHTrab found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_GetById").WithDisplayName("Get StatusHTrab By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusHTrab? filtro, string uri, IStatusHTrabService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_GetListN").WithDisplayName("Get StatusHTrab List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusHTrab regStatusHTrab, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            var result = await service.AddAndUpdate(regStatusHTrab, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_AddAndUpdate").WithDisplayName("Add or Update StatusHTrab");
        group.MapDelete("/Delete", async (int id, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_Delete").WithDisplayName("Delete StatusHTrab");
    }
}