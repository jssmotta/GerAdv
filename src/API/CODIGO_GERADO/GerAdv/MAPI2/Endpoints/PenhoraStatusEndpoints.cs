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
        group.MapGet("/GetAll", async (int max, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("PenhoraStatus: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetAll").WithDisplayName("Get All PenhoraStatus");
        group.MapPost("/Filter", async (Filters.FilterPenhoraStatus filtro, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            logger.Info("PenhoraStatus: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_Filter").WithDisplayName("Filter PenhoraStatus");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service, CancellationToken token) =>
        {
            logger.Info("PenhoraStatus: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PenhoraStatus found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetById").WithDisplayName("Get PenhoraStatus By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            logger.Info("PenhoraStatus: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No PenhoraStatus found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetByName").WithDisplayName("Get PenhoraStatus By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPenhoraStatus? filtro, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            logger.Info("PenhoraStatus: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PenhoraStatus_GetListN").WithDisplayName("Get PenhoraStatus List N");
        group.MapPost("/AddAndUpdate", async (Models.PenhoraStatus regPenhoraStatus, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            logger.LogInfo("PenhoraStatus", "AddAndUpdate", $"regPenhoraStatus = {regPenhoraStatus}", uri);
            var result = await service.AddAndUpdate(regPenhoraStatus, uri);
            if (result == null)
            {
                logger.LogWarn("PenhoraStatus", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_AddAndUpdate").WithDisplayName("Add or Update PenhoraStatus");
        group.MapDelete("/Delete", async (int id, string uri, IPenhoraStatusValidation validation, IPenhoraStatusWriter writer, IPenhoraStatusService service) =>
        {
            logger.LogInfo("PenhoraStatus", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("PenhoraStatus", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PenhoraStatus_Delete").WithDisplayName("Delete PenhoraStatus");
    }
}