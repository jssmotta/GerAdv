#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AreasJusticaEndpoints
{
    public static IEndpointRouteBuilder MapAreasJusticaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AreasJustica").WithTags("AreasJustica").RequireAuthorization();
        MapAreasJusticaRoutes(group);
        return app;
    }

    private static void MapAreasJusticaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAreasJusticaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AreasJustica_GetAll").WithDisplayName("Get All AreasJustica");
        group.MapPost("/Filter", async (Filters.FilterAreasJustica filtro, string uri, IAreasJusticaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AreasJustica_Filter").WithDisplayName("Filter AreasJustica");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAreasJusticaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AreasJustica found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AreasJustica_GetById").WithDisplayName("Get AreasJustica By Id");
        group.MapPost("/AddAndUpdate", async (Models.AreasJustica regAreasJustica, string uri, IAreasJusticaValidation validation, IAreasJusticaWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IAreasJusticaService service) =>
        {
            var result = await service.AddAndUpdate(regAreasJustica, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AreasJustica_AddAndUpdate").WithDisplayName("Add or Update AreasJustica");
        group.MapDelete("/Delete", async (int id, string uri, IAreasJusticaValidation validation, IAreasJusticaWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IAreasJusticaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AreasJustica_Delete").WithDisplayName("Delete AreasJustica");
    }
}