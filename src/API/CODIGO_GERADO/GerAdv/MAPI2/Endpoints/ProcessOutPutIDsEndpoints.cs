#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutPutIDsEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutPutIDsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutPutIDs").WithTags("ProcessOutPutIDs").RequireAuthorization();
        MapProcessOutPutIDsRoutes(group);
        return app;
    }

    private static void MapProcessOutPutIDsRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessOutPutIDs: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetAll").WithDisplayName("Get All ProcessOutPutIDs");
        group.MapPost("/Filter", async (Filters.FilterProcessOutPutIDs filtro, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.Info("ProcessOutPutIDs: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_Filter").WithDisplayName("Filter ProcessOutPutIDs");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service, CancellationToken token) =>
        {
            logger.Info("ProcessOutPutIDs: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutPutIDs found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetById").WithDisplayName("Get ProcessOutPutIDs By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.Info("ProcessOutPutIDs: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProcessOutPutIDs found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetByName").WithDisplayName("Get ProcessOutPutIDs By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutPutIDs? filtro, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.Info("ProcessOutPutIDs: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetListN").WithDisplayName("Get ProcessOutPutIDs List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutPutIDs regProcessOutPutIDs, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.LogInfo("ProcessOutPutIDs", "AddAndUpdate", $"regProcessOutPutIDs = {regProcessOutPutIDs}", uri);
            var result = await service.AddAndUpdate(regProcessOutPutIDs, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutPutIDs", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_AddAndUpdate").WithDisplayName("Add or Update ProcessOutPutIDs");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.LogInfo("ProcessOutPutIDs", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutPutIDs", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetColumns").WithDisplayName("Get ProcessOutPutIDs Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.LogInfo("ProcessOutPutIDs", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProcessOutPutIDs", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProcessOutPutIDs_UpdateColumns").WithDisplayName("Update ProcessOutPutIDs Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            logger.LogInfo("ProcessOutPutIDs", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutPutIDs", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_Delete").WithDisplayName("Delete ProcessOutPutIDs");
    }
}