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
        group.MapGet("/GetAll", async (int max, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Tribunal: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_GetAll").WithDisplayName("Get All Tribunal");
        group.MapPost("/Filter", async (Filters.FilterTribunal filtro, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            logger.Info("Tribunal: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_Filter").WithDisplayName("Filter Tribunal");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service, CancellationToken token) =>
        {
            logger.Info("Tribunal: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Tribunal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_GetById").WithDisplayName("Get Tribunal By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            logger.Info("Tribunal: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Tribunal found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_GetByName").WithDisplayName("Get Tribunal By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTribunal? filtro, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            logger.Info("Tribunal: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Tribunal_GetListN").WithDisplayName("Get Tribunal List N");
        group.MapPost("/AddAndUpdate", async (Models.Tribunal regTribunal, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            logger.LogInfo("Tribunal", "AddAndUpdate", $"regTribunal = {regTribunal}", uri);
            var result = await service.AddAndUpdate(regTribunal, uri);
            if (result == null)
            {
                logger.LogWarn("Tribunal", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_AddAndUpdate").WithDisplayName("Add or Update Tribunal");
        group.MapDelete("/Delete", async (int id, string uri, ITribunalValidation validation, ITribunalWriter writer, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, ITribunalService service) =>
        {
            logger.LogInfo("Tribunal", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Tribunal", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Tribunal_Delete").WithDisplayName("Delete Tribunal");
    }
}