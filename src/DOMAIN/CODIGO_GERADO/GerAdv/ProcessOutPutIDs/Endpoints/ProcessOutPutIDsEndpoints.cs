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
        group.MapGet("/GetAll", async (int max, string uri, IProcessOutPutIDsService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetAll").WithDisplayName("Get All ProcessOutPutIDs");
        group.MapPost("/Filter", async (Filters.FilterProcessOutPutIDs filtro, string uri, IProcessOutPutIDsService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_Filter").WithDisplayName("Filter ProcessOutPutIDs");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessOutPutIDsService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessOutPutIDs found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetById").WithDisplayName("Get ProcessOutPutIDs By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessOutPutIDs? filtro, string uri, IProcessOutPutIDsService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_GetListN").WithDisplayName("Get ProcessOutPutIDs List N");
        group.MapPost("/AddAndUpdate", async (Models.ProcessOutPutIDs regProcessOutPutIDs, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            var result = await service.AddAndUpdate(regProcessOutPutIDs, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_AddAndUpdate").WithDisplayName("Add or Update ProcessOutPutIDs");
        group.MapDelete("/Delete", async (int id, string uri, IProcessOutPutIDsValidation validation, IProcessOutPutIDsWriter writer, IProcessOutPutIDsService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessOutPutIDs_Delete").WithDisplayName("Delete ProcessOutPutIDs");
    }
}