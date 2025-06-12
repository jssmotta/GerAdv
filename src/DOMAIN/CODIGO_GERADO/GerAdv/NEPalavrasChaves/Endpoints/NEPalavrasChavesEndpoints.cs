#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NEPalavrasChavesEndpoints
{
    public static IEndpointRouteBuilder MapNEPalavrasChavesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NEPalavrasChaves").WithTags("NEPalavrasChaves").RequireAuthorization();
        MapNEPalavrasChavesRoutes(group);
        return app;
    }

    private static void MapNEPalavrasChavesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INEPalavrasChavesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetAll").WithDisplayName("Get All NEPalavrasChaves");
        group.MapPost("/Filter", async (Filters.FilterNEPalavrasChaves filtro, string uri, INEPalavrasChavesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_Filter").WithDisplayName("Filter NEPalavrasChaves");
        group.MapGet("/GetById/{id}", async (int id, string uri, INEPalavrasChavesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NEPalavrasChaves found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetById").WithDisplayName("Get NEPalavrasChaves By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterNEPalavrasChaves? filtro, string uri, INEPalavrasChavesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetListN").WithDisplayName("Get NEPalavrasChaves List N");
        group.MapPost("/AddAndUpdate", async (Models.NEPalavrasChaves regNEPalavrasChaves, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            var result = await service.AddAndUpdate(regNEPalavrasChaves, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_AddAndUpdate").WithDisplayName("Add or Update NEPalavrasChaves");
        group.MapDelete("/Delete", async (int id, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_Delete").WithDisplayName("Delete NEPalavrasChaves");
    }
}