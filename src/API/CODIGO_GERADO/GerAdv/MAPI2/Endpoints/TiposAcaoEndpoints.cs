#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TiposAcaoEndpoints
{
    public static IEndpointRouteBuilder MapTiposAcaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TiposAcao").WithTags("TiposAcao").RequireAuthorization();
        MapTiposAcaoRoutes(group);
        return app;
    }

    private static void MapTiposAcaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TiposAcao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_GetAll").WithDisplayName("Get All TiposAcao");
        group.MapPost("/Filter", async (Filters.FilterTiposAcao filtro, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            logger.Info("TiposAcao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_Filter").WithDisplayName("Filter TiposAcao");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service, CancellationToken token) =>
        {
            logger.Info("TiposAcao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TiposAcao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_GetById").WithDisplayName("Get TiposAcao By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            logger.Info("TiposAcao: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TiposAcao found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_GetByName").WithDisplayName("Get TiposAcao By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTiposAcao? filtro, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            logger.Info("TiposAcao: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_GetListN").WithDisplayName("Get TiposAcao List N");
        group.MapPost("/AddAndUpdate", async (Models.TiposAcao regTiposAcao, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            logger.LogInfo("TiposAcao", "AddAndUpdate", $"regTiposAcao = {regTiposAcao}", uri);
            var result = await service.AddAndUpdate(regTiposAcao, uri);
            if (result == null)
            {
                logger.LogWarn("TiposAcao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_AddAndUpdate").WithDisplayName("Add or Update TiposAcao");
        group.MapDelete("/Delete", async (int id, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            logger.LogInfo("TiposAcao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TiposAcao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_Delete").WithDisplayName("Delete TiposAcao");
    }
}