#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class BensClassificacaoEndpoints
{
    public static IEndpointRouteBuilder MapBensClassificacaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/BensClassificacao").WithTags("BensClassificacao").RequireAuthorization();
        MapBensClassificacaoRoutes(group);
        return app;
    }

    private static void MapBensClassificacaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("BensClassificacao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("BensClassificacao_GetAll").WithDisplayName("Get All BensClassificacao");
        group.MapPost("/Filter", async (Filters.FilterBensClassificacao filtro, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            logger.Info("BensClassificacao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("BensClassificacao_Filter").WithDisplayName("Filter BensClassificacao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service, CancellationToken token) =>
        {
            logger.Info("BensClassificacao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No BensClassificacao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensClassificacao_GetById").WithDisplayName("Get BensClassificacao By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            logger.Info("BensClassificacao: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No BensClassificacao found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensClassificacao_GetByName").WithDisplayName("Get BensClassificacao By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterBensClassificacao? filtro, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            logger.Info("BensClassificacao: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("BensClassificacao_GetListN").WithDisplayName("Get BensClassificacao List N");
        group.MapPost("/AddAndUpdate", async (Models.BensClassificacao regBensClassificacao, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            logger.LogInfo("BensClassificacao", "AddAndUpdate", $"regBensClassificacao = {regBensClassificacao}", uri);
            var result = await service.AddAndUpdate(regBensClassificacao, uri);
            if (result == null)
            {
                logger.LogWarn("BensClassificacao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("BensClassificacao_AddAndUpdate").WithDisplayName("Add or Update BensClassificacao");
        group.MapDelete("/Delete", async (int id, string uri, IBensClassificacaoValidation validation, IBensClassificacaoWriter writer, IBensClassificacaoService service) =>
        {
            logger.LogInfo("BensClassificacao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("BensClassificacao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensClassificacao_Delete").WithDisplayName("Delete BensClassificacao");
    }
}