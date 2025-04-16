#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTPeriodicidadeStatusEndpoints
{
    public static IEndpointRouteBuilder MapGUTPeriodicidadeStatusEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTPeriodicidadeStatus").WithTags("GUTPeriodicidadeStatus").RequireAuthorization();
        MapGUTPeriodicidadeStatusRoutes(group);
        return app;
    }

    private static void MapGUTPeriodicidadeStatusRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTPeriodicidadeStatus: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_GetAll").WithDisplayName("Get All GUTPeriodicidadeStatus");
        group.MapPost("/Filter", async (Filters.FilterGUTPeriodicidadeStatus filtro, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            logger.Info("GUTPeriodicidadeStatus: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_Filter").WithDisplayName("Filter GUTPeriodicidadeStatus");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service, CancellationToken token) =>
        {
            logger.Info("GUTPeriodicidadeStatus: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTPeriodicidadeStatus found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_GetById").WithDisplayName("Get GUTPeriodicidadeStatus By Id");
        group.MapPost("/AddAndUpdate", async (Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            logger.LogInfo("GUTPeriodicidadeStatus", "AddAndUpdate", $"regGUTPeriodicidadeStatus = {regGUTPeriodicidadeStatus}", uri);
            var result = await service.AddAndUpdate(regGUTPeriodicidadeStatus, uri);
            if (result == null)
            {
                logger.LogWarn("GUTPeriodicidadeStatus", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_AddAndUpdate").WithDisplayName("Add or Update GUTPeriodicidadeStatus");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            logger.LogInfo("GUTPeriodicidadeStatus", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("GUTPeriodicidadeStatus", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_GetColumns").WithDisplayName("Get GUTPeriodicidadeStatus Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            logger.LogInfo("GUTPeriodicidadeStatus", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("GUTPeriodicidadeStatus", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("GUTPeriodicidadeStatus_UpdateColumns").WithDisplayName("Update GUTPeriodicidadeStatus Columns");
        group.MapDelete("/Delete", async (int id, string uri, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IGUTPeriodicidadeStatusService service) =>
        {
            logger.LogInfo("GUTPeriodicidadeStatus", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTPeriodicidadeStatus", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidadeStatus_Delete").WithDisplayName("Delete GUTPeriodicidadeStatus");
    }
}