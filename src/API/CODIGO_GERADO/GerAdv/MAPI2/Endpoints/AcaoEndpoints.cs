#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AcaoEndpoints
{
    public static IEndpointRouteBuilder MapAcaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Acao").WithTags("Acao").RequireAuthorization();
        MapAcaoRoutes(group);
        return app;
    }

    private static void MapAcaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Acao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Acao_GetAll").WithDisplayName("Get All Acao");
        group.MapPost("/Filter", async (Filters.FilterAcao filtro, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            logger.Info("Acao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Acao_Filter").WithDisplayName("Filter Acao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service, CancellationToken token) =>
        {
            logger.Info("Acao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Acao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Acao_GetById").WithDisplayName("Get Acao By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            logger.Info("Acao: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Acao found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Acao_GetByName").WithDisplayName("Get Acao By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAcao? filtro, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            logger.Info("Acao: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Acao_GetListN").WithDisplayName("Get Acao List N");
        group.MapPost("/AddAndUpdate", async (Models.Acao regAcao, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            logger.LogInfo("Acao", "AddAndUpdate", $"regAcao = {regAcao}", uri);
            var result = await service.AddAndUpdate(regAcao, uri);
            if (result == null)
            {
                logger.LogWarn("Acao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Acao_AddAndUpdate").WithDisplayName("Add or Update Acao");
        group.MapDelete("/Delete", async (int id, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            logger.LogInfo("Acao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Acao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Acao_Delete").WithDisplayName("Delete Acao");
    }
}