#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class SituacaoEndpoints
{
    public static IEndpointRouteBuilder MapSituacaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Situacao").WithTags("Situacao").RequireAuthorization();
        MapSituacaoRoutes(group);
        return app;
    }

    private static void MapSituacaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Situacao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Situacao_GetAll").WithDisplayName("Get All Situacao");
        group.MapPost("/Filter", async (Filters.FilterSituacao filtro, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            logger.Info("Situacao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Situacao_Filter").WithDisplayName("Filter Situacao");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service, CancellationToken token) =>
        {
            logger.Info("Situacao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Situacao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Situacao_GetById").WithDisplayName("Get Situacao By Id");
        group.MapPost("/AddAndUpdate", async (Models.Situacao regSituacao, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            logger.LogInfo("Situacao", "AddAndUpdate", $"regSituacao = {regSituacao}", uri);
            var result = await service.AddAndUpdate(regSituacao, uri);
            if (result == null)
            {
                logger.LogWarn("Situacao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Situacao_AddAndUpdate").WithDisplayName("Add or Update Situacao");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            logger.LogInfo("Situacao", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Situacao", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Situacao_GetColumns").WithDisplayName("Get Situacao Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            logger.LogInfo("Situacao", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Situacao", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Situacao_UpdateColumns").WithDisplayName("Update Situacao Columns");
        group.MapDelete("/Delete", async (int id, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            logger.LogInfo("Situacao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Situacao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Situacao_Delete").WithDisplayName("Delete Situacao");
    }
}