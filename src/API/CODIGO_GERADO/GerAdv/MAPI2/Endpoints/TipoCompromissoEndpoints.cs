#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoCompromissoEndpoints
{
    public static IEndpointRouteBuilder MapTipoCompromissoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoCompromisso").WithTags("TipoCompromisso").RequireAuthorization();
        MapTipoCompromissoRoutes(group);
        return app;
    }

    private static void MapTipoCompromissoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoCompromisso: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetAll").WithDisplayName("Get All TipoCompromisso");
        group.MapPost("/Filter", async (Filters.FilterTipoCompromisso filtro, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.Info("TipoCompromisso: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_Filter").WithDisplayName("Filter TipoCompromisso");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service, CancellationToken token) =>
        {
            logger.Info("TipoCompromisso: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoCompromisso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetById").WithDisplayName("Get TipoCompromisso By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.Info("TipoCompromisso: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoCompromisso found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetByName").WithDisplayName("Get TipoCompromisso By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoCompromisso? filtro, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.Info("TipoCompromisso: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetListN").WithDisplayName("Get TipoCompromisso List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoCompromisso regTipoCompromisso, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.LogInfo("TipoCompromisso", "AddAndUpdate", $"regTipoCompromisso = {regTipoCompromisso}", uri);
            var result = await service.AddAndUpdate(regTipoCompromisso, uri);
            if (result == null)
            {
                logger.LogWarn("TipoCompromisso", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_AddAndUpdate").WithDisplayName("Add or Update TipoCompromisso");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.LogInfo("TipoCompromisso", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoCompromisso", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetColumns").WithDisplayName("Get TipoCompromisso Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.LogInfo("TipoCompromisso", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoCompromisso", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoCompromisso_UpdateColumns").WithDisplayName("Update TipoCompromisso Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            logger.LogInfo("TipoCompromisso", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoCompromisso", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_Delete").WithDisplayName("Delete TipoCompromisso");
    }
}