#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusHTrabEndpoints
{
    public static IEndpointRouteBuilder MapStatusHTrabEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusHTrab").WithTags("StatusHTrab").RequireAuthorization();
        MapStatusHTrabRoutes(group);
        return app;
    }

    private static void MapStatusHTrabRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("StatusHTrab: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_GetAll").WithDisplayName("Get All StatusHTrab");
        group.MapPost("/Filter", async (Filters.FilterStatusHTrab filtro, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            logger.Info("StatusHTrab: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_Filter").WithDisplayName("Filter StatusHTrab");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service, CancellationToken token) =>
        {
            logger.Info("StatusHTrab: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusHTrab found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_GetById").WithDisplayName("Get StatusHTrab By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            logger.Info("StatusHTrab: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No StatusHTrab found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_GetByName").WithDisplayName("Get StatusHTrab By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusHTrab? filtro, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            logger.Info("StatusHTrab: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusHTrab_GetListN").WithDisplayName("Get StatusHTrab List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusHTrab regStatusHTrab, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            logger.LogInfo("StatusHTrab", "AddAndUpdate", $"regStatusHTrab = {regStatusHTrab}", uri);
            var result = await service.AddAndUpdate(regStatusHTrab, uri);
            if (result == null)
            {
                logger.LogWarn("StatusHTrab", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_AddAndUpdate").WithDisplayName("Add or Update StatusHTrab");
        group.MapDelete("/Delete", async (int id, string uri, IStatusHTrabValidation validation, IStatusHTrabWriter writer, IStatusHTrabService service) =>
        {
            logger.LogInfo("StatusHTrab", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("StatusHTrab", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusHTrab_Delete").WithDisplayName("Delete StatusHTrab");
    }
}