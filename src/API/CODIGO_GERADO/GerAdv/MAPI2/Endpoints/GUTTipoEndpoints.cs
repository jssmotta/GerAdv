#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTTipoEndpoints
{
    public static IEndpointRouteBuilder MapGUTTipoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTTipo").WithTags("GUTTipo").RequireAuthorization();
        MapGUTTipoRoutes(group);
        return app;
    }

    private static void MapGUTTipoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTTipo: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_GetAll").WithDisplayName("Get All GUTTipo");
        group.MapPost("/Filter", async (Filters.FilterGUTTipo filtro, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.Info("GUTTipo: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_Filter").WithDisplayName("Filter GUTTipo");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service, CancellationToken token) =>
        {
            logger.Info("GUTTipo: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTTipo found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_GetById").WithDisplayName("Get GUTTipo By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.Info("GUTTipo: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No GUTTipo found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_GetByName").WithDisplayName("Get GUTTipo By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTTipo? filtro, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.Info("GUTTipo: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_GetListN").WithDisplayName("Get GUTTipo List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTTipo regGUTTipo, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.LogInfo("GUTTipo", "AddAndUpdate", $"regGUTTipo = {regGUTTipo}", uri);
            var result = await service.AddAndUpdate(regGUTTipo, uri);
            if (result == null)
            {
                logger.LogWarn("GUTTipo", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_AddAndUpdate").WithDisplayName("Add or Update GUTTipo");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.LogInfo("GUTTipo", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("GUTTipo", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_GetColumns").WithDisplayName("Get GUTTipo Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.LogInfo("GUTTipo", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("GUTTipo", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("GUTTipo_UpdateColumns").WithDisplayName("Update GUTTipo Columns");
        group.MapDelete("/Delete", async (int id, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            logger.LogInfo("GUTTipo", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTTipo", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_Delete").WithDisplayName("Delete GUTTipo");
    }
}