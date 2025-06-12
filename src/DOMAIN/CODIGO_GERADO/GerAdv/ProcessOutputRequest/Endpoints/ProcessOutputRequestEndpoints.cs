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
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutputRequestService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_GetAll").WithDisplayName("Get All ProcessOutputRequest");
        group.MapPost("/Filter", async (Filters.FilterProcessOutputRequest filtro, string uri, IProcessOutputRequestService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_Filter").WithDisplayName("Filter ProcessOutputRequest");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutputRequestService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regProcessOutputRequest, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_AddAndUpdate").WithDisplayName("Add or Update ProcessOutputRequest");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IProcessOutputRequestService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutputRequest_Delete").WithDisplayName("Delete ProcessOutputRequest");
    }
}