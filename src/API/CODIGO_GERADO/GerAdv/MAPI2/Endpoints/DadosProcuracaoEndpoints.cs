#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DadosProcuracaoEndpoints
{
    public static IEndpointRouteBuilder MapDadosProcuracaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/DadosProcuracao").WithTags("DadosProcuracao").RequireAuthorization();
        MapDadosProcuracaoRoutes(group);
        return app;
    }

    private static void MapDadosProcuracaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("DadosProcuracao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DadosProcuracao_GetAll").WithDisplayName("Get All DadosProcuracao");
        group.MapPost("/Filter", async (Filters.FilterDadosProcuracao filtro, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            logger.Info("DadosProcuracao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DadosProcuracao_Filter").WithDisplayName("Filter DadosProcuracao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service, CancellationToken token) =>
        {
            logger.Info("DadosProcuracao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DadosProcuracao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_GetById").WithDisplayName("Get DadosProcuracao By Id");
        group.MapPost("/AddAndUpdate", async (Models.DadosProcuracao regDadosProcuracao, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            logger.LogInfo("DadosProcuracao", "AddAndUpdate", $"regDadosProcuracao = {regDadosProcuracao}", uri);
            var result = await service.AddAndUpdate(regDadosProcuracao, uri);
            if (result == null)
            {
                logger.LogWarn("DadosProcuracao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_AddAndUpdate").WithDisplayName("Add or Update DadosProcuracao");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            logger.LogInfo("DadosProcuracao", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("DadosProcuracao", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_GetColumns").WithDisplayName("Get DadosProcuracao Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            logger.LogInfo("DadosProcuracao", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("DadosProcuracao", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("DadosProcuracao_UpdateColumns").WithDisplayName("Update DadosProcuracao Columns");
        group.MapDelete("/Delete", async (int id, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            logger.LogInfo("DadosProcuracao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("DadosProcuracao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_Delete").WithDisplayName("Delete DadosProcuracao");
    }
}