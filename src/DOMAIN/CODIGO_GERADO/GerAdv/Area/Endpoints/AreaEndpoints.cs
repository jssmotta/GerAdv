#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AreaEndpoints
{
    public static IEndpointRouteBuilder MapAreaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Area").WithTags("Area").RequireAuthorization();
        MapAreaRoutes(group);
        return app;
    }

    private static void MapAreaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAreaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Area_GetAll").WithDisplayName("Get All Area");
        group.MapPost("/Filter", async (Filters.FilterArea filtro, string uri, IAreaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Area_Filter").WithDisplayName("Filter Area");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAreaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Area found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_GetById").WithDisplayName("Get Area By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterArea? filtro, string uri, IAreaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Area_GetListN").WithDisplayName("Get Area List N");
        group.MapPost("/AddAndUpdate", async (Models.Area regArea, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            var result = await service.AddAndUpdate(regArea, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Area_AddAndUpdate").WithDisplayName("Add or Update Area");
        group.MapDelete("/Delete", async (int id, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_Delete").WithDisplayName("Delete Area");
    }
}