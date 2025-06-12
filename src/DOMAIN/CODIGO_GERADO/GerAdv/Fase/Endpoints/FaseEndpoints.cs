#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FaseEndpoints
{
    public static IEndpointRouteBuilder MapFaseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Fase").WithTags("Fase").RequireAuthorization();
        MapFaseRoutes(group);
        return app;
    }

    private static void MapFaseRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFaseService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Fase_GetAll").WithDisplayName("Get All Fase");
        group.MapPost("/Filter", async (Filters.FilterFase filtro, string uri, IFaseService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Fase_Filter").WithDisplayName("Filter Fase");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFaseService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Fase found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fase_GetById").WithDisplayName("Get Fase By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterFase? filtro, string uri, IFaseService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Fase_GetListN").WithDisplayName("Get Fase List N");
        group.MapPost("/AddAndUpdate", async (Models.Fase regFase, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            var result = await service.AddAndUpdate(regFase, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Fase_AddAndUpdate").WithDisplayName("Add or Update Fase");
        group.MapDelete("/Delete", async (int id, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fase_Delete").WithDisplayName("Delete Fase");
    }
}