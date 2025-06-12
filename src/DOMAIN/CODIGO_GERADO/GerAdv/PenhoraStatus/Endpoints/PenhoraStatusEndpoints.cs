#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PenhoraStatusEndpoints
{
    public static IEndpointRouteBuilder MapPenhoraStatusEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PenhoraStatus").WithTags("PenhoraStatus").RequireAuthorization();
        MapPenhoraStatusRoutes(group);
        return app;
    }

    private static void MapPenhoraStatusRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPenhoraStatusService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetAll").WithDisplayName("Get All PenhoraStatus");
        group.MapPost("/Filter", async (Filters.FilterPenhoraStatus filtro, string uri, IPenhoraStatusService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_Filter").WithDisplayName("Filter PenhoraStatus");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPenhoraStatusService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PenhoraStatus found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetById").WithDisplayName("Get PenhoraStatus By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPenhoraStatus? filtro, string uri, IPenhoraStatusService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetListN").WithDisplayName("Get PenhoraStatus List N");
        group.MapPost("/AddAndUpdate", async (Models.PenhoraStatus regPenhoraStatus, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            var result = await service.AddAndUpdate(regPenhoraStatus, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_AddAndUpdate").WithDisplayName("Add or Update PenhoraStatus");
        group.MapDelete("/Delete", async (int id, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_Delete").WithDisplayName("Delete PenhoraStatus");
    }
}