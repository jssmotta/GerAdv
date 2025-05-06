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
        group.MapGet("/GetAll", async (int max, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Fase: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Fase_GetAll").WithDisplayName("Get All Fase");
        group.MapPost("/Filter", async (Filters.FilterFase filtro, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            logger.Info("Fase: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Fase_Filter").WithDisplayName("Filter Fase");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service, CancellationToken token) =>
        {
            logger.Info("Fase: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Fase found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fase_GetById").WithDisplayName("Get Fase By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            logger.Info("Fase: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Fase found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fase_GetByName").WithDisplayName("Get Fase By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterFase? filtro, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            logger.Info("Fase: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Fase_GetListN").WithDisplayName("Get Fase List N");
        group.MapPost("/AddAndUpdate", async (Models.Fase regFase, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            logger.LogInfo("Fase", "AddAndUpdate", $"regFase = {regFase}", uri);
            var result = await service.AddAndUpdate(regFase, uri);
            if (result == null)
            {
                logger.LogWarn("Fase", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Fase_AddAndUpdate").WithDisplayName("Add or Update Fase");
        group.MapDelete("/Delete", async (int id, string uri, IFaseValidation validation, IFaseWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IFaseService service) =>
        {
            logger.LogInfo("Fase", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Fase", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fase_Delete").WithDisplayName("Delete Fase");
    }
}