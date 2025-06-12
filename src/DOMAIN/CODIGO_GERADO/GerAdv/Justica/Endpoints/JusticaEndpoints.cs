#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class JusticaEndpoints
{
    public static IEndpointRouteBuilder MapJusticaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Justica").WithTags("Justica").RequireAuthorization();
        MapJusticaRoutes(group);
        return app;
    }

    private static void MapJusticaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IJusticaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Justica_GetAll").WithDisplayName("Get All Justica");
        group.MapPost("/Filter", async (Filters.FilterJustica filtro, string uri, IJusticaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Justica_Filter").WithDisplayName("Filter Justica");
        group.MapGet("/GetById/{id}", async (int id, string uri, IJusticaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Justica found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Justica_GetById").WithDisplayName("Get Justica By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterJustica? filtro, string uri, IJusticaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Justica_GetListN").WithDisplayName("Get Justica List N");
        group.MapPost("/AddAndUpdate", async (Models.Justica regJustica, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            var result = await service.AddAndUpdate(regJustica, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Justica_AddAndUpdate").WithDisplayName("Add or Update Justica");
        group.MapDelete("/Delete", async (int id, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Justica_Delete").WithDisplayName("Delete Justica");
    }
}