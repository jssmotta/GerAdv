#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTMatrizEndpoints
{
    public static IEndpointRouteBuilder MapGUTMatrizEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTMatriz").WithTags("GUTMatriz").RequireAuthorization();
        MapGUTMatrizRoutes(group);
        return app;
    }

    private static void MapGUTMatrizRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTMatriz: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_GetAll").WithDisplayName("Get All GUTMatriz");
        group.MapPost("/Filter", async (Filters.FilterGUTMatriz filtro, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.Info("GUTMatriz: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_Filter").WithDisplayName("Filter GUTMatriz");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service, CancellationToken token) =>
        {
            logger.Info("GUTMatriz: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTMatriz found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_GetById").WithDisplayName("Get GUTMatriz By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.Info("GUTMatriz: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No GUTMatriz found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_GetByName").WithDisplayName("Get GUTMatriz By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTMatriz? filtro, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.Info("GUTMatriz: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_GetListN").WithDisplayName("Get GUTMatriz List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTMatriz regGUTMatriz, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.LogInfo("GUTMatriz", "AddAndUpdate", $"regGUTMatriz = {regGUTMatriz}", uri);
            var result = await service.AddAndUpdate(regGUTMatriz, uri);
            if (result == null)
            {
                logger.LogWarn("GUTMatriz", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_AddAndUpdate").WithDisplayName("Add or Update GUTMatriz");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.LogInfo("GUTMatriz", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("GUTMatriz", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_GetColumns").WithDisplayName("Get GUTMatriz Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.LogInfo("GUTMatriz", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("GUTMatriz", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("GUTMatriz_UpdateColumns").WithDisplayName("Update GUTMatriz Columns");
        group.MapDelete("/Delete", async (int id, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            logger.LogInfo("GUTMatriz", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTMatriz", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_Delete").WithDisplayName("Delete GUTMatriz");
    }
}