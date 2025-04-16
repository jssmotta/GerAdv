#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RegimeTributacaoEndpoints
{
    public static IEndpointRouteBuilder MapRegimeTributacaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/RegimeTributacao").WithTags("RegimeTributacao").RequireAuthorization();
        MapRegimeTributacaoRoutes(group);
        return app;
    }

    private static void MapRegimeTributacaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("RegimeTributacao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetAll").WithDisplayName("Get All RegimeTributacao");
        group.MapPost("/Filter", async (Filters.FilterRegimeTributacao filtro, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.Info("RegimeTributacao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_Filter").WithDisplayName("Filter RegimeTributacao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service, CancellationToken token) =>
        {
            logger.Info("RegimeTributacao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No RegimeTributacao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetById").WithDisplayName("Get RegimeTributacao By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.Info("RegimeTributacao: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No RegimeTributacao found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetByName").WithDisplayName("Get RegimeTributacao By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterRegimeTributacao? filtro, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.Info("RegimeTributacao: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetListN").WithDisplayName("Get RegimeTributacao List N");
        group.MapPost("/AddAndUpdate", async (Models.RegimeTributacao regRegimeTributacao, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.LogInfo("RegimeTributacao", "AddAndUpdate", $"regRegimeTributacao = {regRegimeTributacao}", uri);
            var result = await service.AddAndUpdate(regRegimeTributacao, uri);
            if (result == null)
            {
                logger.LogWarn("RegimeTributacao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_AddAndUpdate").WithDisplayName("Add or Update RegimeTributacao");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.LogInfo("RegimeTributacao", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("RegimeTributacao", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetColumns").WithDisplayName("Get RegimeTributacao Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.LogInfo("RegimeTributacao", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("RegimeTributacao", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("RegimeTributacao_UpdateColumns").WithDisplayName("Update RegimeTributacao Columns");
        group.MapDelete("/Delete", async (int id, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            logger.LogInfo("RegimeTributacao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("RegimeTributacao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_Delete").WithDisplayName("Delete RegimeTributacao");
    }
}