#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoProDespositoEndpoints
{
    public static IEndpointRouteBuilder MapTipoProDespositoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoProDesposito").WithTags("TipoProDesposito").RequireAuthorization();
        MapTipoProDespositoRoutes(group);
        return app;
    }

    private static void MapTipoProDespositoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoProDesposito: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetAll").WithDisplayName("Get All TipoProDesposito");
        group.MapPost("/Filter", async (Filters.FilterTipoProDesposito filtro, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.Info("TipoProDesposito: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_Filter").WithDisplayName("Filter TipoProDesposito");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service, CancellationToken token) =>
        {
            logger.Info("TipoProDesposito: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoProDesposito found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetById").WithDisplayName("Get TipoProDesposito By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.Info("TipoProDesposito: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoProDesposito found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetByName").WithDisplayName("Get TipoProDesposito By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoProDesposito? filtro, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.Info("TipoProDesposito: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetListN").WithDisplayName("Get TipoProDesposito List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoProDesposito regTipoProDesposito, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.LogInfo("TipoProDesposito", "AddAndUpdate", $"regTipoProDesposito = {regTipoProDesposito}", uri);
            var result = await service.AddAndUpdate(regTipoProDesposito, uri);
            if (result == null)
            {
                logger.LogWarn("TipoProDesposito", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_AddAndUpdate").WithDisplayName("Add or Update TipoProDesposito");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.LogInfo("TipoProDesposito", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoProDesposito", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetColumns").WithDisplayName("Get TipoProDesposito Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.LogInfo("TipoProDesposito", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoProDesposito", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoProDesposito_UpdateColumns").WithDisplayName("Update TipoProDesposito Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            logger.LogInfo("TipoProDesposito", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoProDesposito", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_Delete").WithDisplayName("Delete TipoProDesposito");
    }
}