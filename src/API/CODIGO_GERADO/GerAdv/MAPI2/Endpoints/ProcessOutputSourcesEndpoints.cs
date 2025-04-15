#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutputSourcesEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutputSourcesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutputSources").WithTags("ProcessOutputSources").RequireAuthorization();
        MapProcessOutputSourcesRoutes(group);
        return app;
    }

    private static void MapProcessOutputSourcesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessOutputSources: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetAll").WithDisplayName("Get All ProcessOutputSources");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputSources filtro, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.Info("ProcessOutputSources: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_Filter").WithDisplayName("Filter ProcessOutputSources");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service, CancellationToken token) =>
        {
            logger.Info("ProcessOutputSources: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutputSources found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetById").WithDisplayName("Get ProcessOutputSources By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.Info("ProcessOutputSources: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProcessOutputSources found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetByName").WithDisplayName("Get ProcessOutputSources By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutputSources? filtro, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.Info("ProcessOutputSources: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetListN").WithDisplayName("Get ProcessOutputSources List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutputSources regProcessOutputSources, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.LogInfo("ProcessOutputSources", "AddAndUpdate", $"regProcessOutputSources = {regProcessOutputSources}", uri);
            var result = await service.AddAndUpdate(regProcessOutputSources, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputSources", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputSources");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.LogInfo("ProcessOutputSources", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputSources", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_GetColumns").WithDisplayName("Get ProcessOutputSources Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.LogInfo("ProcessOutputSources", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProcessOutputSources", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProcessOutputSources_UpdateColumns").WithDisplayName("Update ProcessOutputSources Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputSourcesValidation validation, IProcessOutputSourcesWriter writer, IProcessOutputSourcesService service) =>
        {
            logger.LogInfo("ProcessOutputSources", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputSources", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputSources_Delete").WithDisplayName("Delete ProcessOutputSources");
    }
}