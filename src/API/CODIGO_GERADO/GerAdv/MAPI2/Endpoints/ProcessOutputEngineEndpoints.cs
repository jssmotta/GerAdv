#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutputEngineEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutputEngineEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutputEngine").WithTags("ProcessOutputEngine").RequireAuthorization();
        MapProcessOutputEngineRoutes(group);
        return app;
    }

    private static void MapProcessOutputEngineRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessOutputEngine: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetAll").WithDisplayName("Get All ProcessOutputEngine");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputEngine filtro, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.Info("ProcessOutputEngine: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_Filter").WithDisplayName("Filter ProcessOutputEngine");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service, CancellationToken token) =>
        {
            logger.Info("ProcessOutputEngine: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutputEngine found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetById").WithDisplayName("Get ProcessOutputEngine By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.Info("ProcessOutputEngine: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProcessOutputEngine found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetByName").WithDisplayName("Get ProcessOutputEngine By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutputEngine? filtro, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.Info("ProcessOutputEngine: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetListN").WithDisplayName("Get ProcessOutputEngine List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutputEngine regProcessOutputEngine, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.LogInfo("ProcessOutputEngine", "AddAndUpdate", $"regProcessOutputEngine = {regProcessOutputEngine}", uri);
            var result = await service.AddAndUpdate(regProcessOutputEngine, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputEngine", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputEngine");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.LogInfo("ProcessOutputEngine", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputEngine", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_GetColumns").WithDisplayName("Get ProcessOutputEngine Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.LogInfo("ProcessOutputEngine", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProcessOutputEngine", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProcessOutputEngine_UpdateColumns").WithDisplayName("Update ProcessOutputEngine Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputEngineService service) =>
        {
            logger.LogInfo("ProcessOutputEngine", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputEngine", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputEngine_Delete").WithDisplayName("Delete ProcessOutputEngine");
    }
}