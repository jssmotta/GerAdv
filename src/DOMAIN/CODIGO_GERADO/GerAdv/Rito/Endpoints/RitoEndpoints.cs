#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RitoEndpoints
{
    public static IEndpointRouteBuilder MapRitoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Rito").WithTags("Rito").RequireAuthorization();
        MapRitoRoutes(group);
        return app;
    }

    private static void MapRitoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRitoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Rito_GetAll").WithDisplayName("Get All Rito");
        group.MapPost("/Filter", async (Filters.FilterRito filtro, string uri, IRitoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Rito_Filter").WithDisplayName("Filter Rito");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRitoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Rito found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Rito_GetById").WithDisplayName("Get Rito By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterRito? filtro, string uri, IRitoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Rito_GetListN").WithDisplayName("Get Rito List N");
        group.MapPost("/AddAndUpdate", async (Models.Rito regRito, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            var result = await service.AddAndUpdate(regRito, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Rito_AddAndUpdate").WithDisplayName("Add or Update Rito");
        group.MapDelete("/Delete", async (int id, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Rito_Delete").WithDisplayName("Delete Rito");
    }
}