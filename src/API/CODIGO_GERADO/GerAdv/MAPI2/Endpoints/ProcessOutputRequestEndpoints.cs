#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessOutputRequestEndpoints
{
    public static IEndpointRouteBuilder MapProcessOutputRequestEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessOutputRequest").WithTags("ProcessOutputRequest").RequireAuthorization();
        MapProcessOutputRequestRoutes(group);
        return app;
    }

    private static void MapProcessOutputRequestRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessOutputRequest: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_GetAll").WithDisplayName("Get All ProcessOutputRequest");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputRequest filtro, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service) =>
        {
            logger.Info("ProcessOutputRequest: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_Filter").WithDisplayName("Filter ProcessOutputRequest");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service, CancellationToken token) =>
        {
            logger.Info("ProcessOutputRequest: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutputRequest found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_GetById").WithDisplayName("Get ProcessOutputRequest By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutputRequest regProcessOutputRequest, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service) =>
        {
            logger.LogInfo("ProcessOutputRequest", "AddAndUpdate", $"regProcessOutputRequest = {regProcessOutputRequest}", uri);
            var result = await service.AddAndUpdate(regProcessOutputRequest, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputRequest", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputRequest");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service) =>
        {
            logger.LogInfo("ProcessOutputRequest", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessOutputRequest", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_Delete").WithDisplayName("Delete ProcessOutputRequest");
    }
}