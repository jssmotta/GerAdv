#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OponentesEndpoints
{
    public static IEndpointRouteBuilder MapOponentesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Oponentes").WithTags("Oponentes").RequireAuthorization();
        MapOponentesRoutes(group);
        return app;
    }

    private static void MapOponentesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOponentesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_GetAll").WithDisplayName("Get All Oponentes");
        group.MapPost("/Filter", async (Filters.FilterOponentes filtro, string uri, IOponentesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_Filter").WithDisplayName("Filter Oponentes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOponentesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Oponentes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_GetById").WithDisplayName("Get Oponentes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOponentes? filtro, string uri, IOponentesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_GetListN").WithDisplayName("Get Oponentes List N");
        group.MapPost("/AddAndUpdate", async (Models.Oponentes regOponentes, string uri, IOponentesValidation validation, IOponentesWriter writer, ICidadeReader cidadeReader, IOponentesService service) =>
        {
            var result = await service.AddAndUpdate(regOponentes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_AddAndUpdate").WithDisplayName("Add or Update Oponentes");
        group.MapDelete("/Delete", async (int id, string uri, IOponentesValidation validation, IOponentesWriter writer, ICidadeReader cidadeReader, IOponentesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_Delete").WithDisplayName("Delete Oponentes");
    }
}