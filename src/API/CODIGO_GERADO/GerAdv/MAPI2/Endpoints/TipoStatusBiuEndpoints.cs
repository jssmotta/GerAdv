#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoStatusBiuEndpoints
{
    public static IEndpointRouteBuilder MapTipoStatusBiuEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoStatusBiu").WithTags("TipoStatusBiu").RequireAuthorization();
        MapTipoStatusBiuRoutes(group);
        return app;
    }

    private static void MapTipoStatusBiuRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoStatusBiu: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetAll").WithDisplayName("Get All TipoStatusBiu");
        group.MapPost("/Filter", async (Filters.FilterTipoStatusBiu filtro, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.Info("TipoStatusBiu: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_Filter").WithDisplayName("Filter TipoStatusBiu");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service, CancellationToken token) =>
        {
            logger.Info("TipoStatusBiu: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoStatusBiu found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetById").WithDisplayName("Get TipoStatusBiu By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.Info("TipoStatusBiu: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoStatusBiu found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetByName").WithDisplayName("Get TipoStatusBiu By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoStatusBiu? filtro, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.Info("TipoStatusBiu: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetListN").WithDisplayName("Get TipoStatusBiu List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoStatusBiu regTipoStatusBiu, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.LogInfo("TipoStatusBiu", "AddAndUpdate", $"regTipoStatusBiu = {regTipoStatusBiu}", uri);
            var result = await service.AddAndUpdate(regTipoStatusBiu, uri);
            if (result == null)
            {
                logger.LogWarn("TipoStatusBiu", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_AddAndUpdate").WithDisplayName("Add or Update TipoStatusBiu");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.LogInfo("TipoStatusBiu", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoStatusBiu", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetColumns").WithDisplayName("Get TipoStatusBiu Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.LogInfo("TipoStatusBiu", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoStatusBiu", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoStatusBiu_UpdateColumns").WithDisplayName("Update TipoStatusBiu Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            logger.LogInfo("TipoStatusBiu", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoStatusBiu", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_Delete").WithDisplayName("Delete TipoStatusBiu");
    }
}