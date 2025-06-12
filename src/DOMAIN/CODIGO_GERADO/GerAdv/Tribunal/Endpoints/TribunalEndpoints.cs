#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TribunalEndpoints
{
    public static IEndpointRouteBuilder MapTribunalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Tribunal").WithTags("Tribunal").RequireAuthorization();
        MapTribunalRoutes(group);
        return app;
    }

    private static void MapTribunalRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITribunalService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_GetAll").WithDisplayName("Get All Tribunal");
        group.MapPost("/Filter", async (Filters.FilterTribunal filtro, string uri, ITribunalService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_Filter").WithDisplayName("Filter Tribunal");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITribunalService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Tribunal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_GetById").WithDisplayName("Get Tribunal By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTribunal? filtro, string uri, ITribunalService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_GetListN").WithDisplayName("Get Tribunal List N");
        group.MapPost("/AddAndUpdate", async (Models.Tribunal regTribunal, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            var result = await service.AddAndUpdate(regTribunal, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_AddAndUpdate").WithDisplayName("Add or Update Tribunal");
        group.MapDelete("/Delete", async (int id, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_Delete").WithDisplayName("Delete Tribunal");
    }
}