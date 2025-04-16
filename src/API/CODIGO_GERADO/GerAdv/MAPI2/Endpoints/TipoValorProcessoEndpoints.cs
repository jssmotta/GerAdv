#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoValorProcessoEndpoints
{
    public static IEndpointRouteBuilder MapTipoValorProcessoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoValorProcesso").WithTags("TipoValorProcesso").RequireAuthorization();
        MapTipoValorProcessoRoutes(group);
        return app;
    }

    private static void MapTipoValorProcessoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoValorProcesso: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoValorProcesso_GetAll").WithDisplayName("Get All TipoValorProcesso");
        group.MapPost("/Filter", async (Filters.FilterTipoValorProcesso filtro, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.Info("TipoValorProcesso: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoValorProcesso_Filter").WithDisplayName("Filter TipoValorProcesso");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service, CancellationToken token) =>
        {
            logger.Info("TipoValorProcesso: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoValorProcesso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoValorProcesso_GetById").WithDisplayName("Get TipoValorProcesso By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.Info("TipoValorProcesso: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoValorProcesso found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoValorProcesso_GetByName").WithDisplayName("Get TipoValorProcesso By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoValorProcesso? filtro, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.Info("TipoValorProcesso: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoValorProcesso_GetListN").WithDisplayName("Get TipoValorProcesso List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoValorProcesso regTipoValorProcesso, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.LogInfo("TipoValorProcesso", "AddAndUpdate", $"regTipoValorProcesso = {regTipoValorProcesso}", uri);
            var result = await service.AddAndUpdate(regTipoValorProcesso, uri);
            if (result == null)
            {
                logger.LogWarn("TipoValorProcesso", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoValorProcesso_AddAndUpdate").WithDisplayName("Add or Update TipoValorProcesso");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.LogInfo("TipoValorProcesso", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoValorProcesso", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoValorProcesso_GetColumns").WithDisplayName("Get TipoValorProcesso Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.LogInfo("TipoValorProcesso", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoValorProcesso", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoValorProcesso_UpdateColumns").WithDisplayName("Update TipoValorProcesso Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, ITipoValorProcessoService service) =>
        {
            logger.LogInfo("TipoValorProcesso", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoValorProcesso", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoValorProcesso_Delete").WithDisplayName("Delete TipoValorProcesso");
    }
}