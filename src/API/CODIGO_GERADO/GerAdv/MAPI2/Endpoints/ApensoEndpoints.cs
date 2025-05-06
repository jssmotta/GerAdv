#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ApensoEndpoints
{
    public static IEndpointRouteBuilder MapApensoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Apenso").WithTags("Apenso").RequireAuthorization();
        MapApensoRoutes(group);
        return app;
    }

    private static void MapApensoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IApensoValidation validation, IApensoWriter writer, IProcessosReader processosReader, IApensoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Apenso: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Apenso_GetAll").WithDisplayName("Get All Apenso");
        group.MapPost("/Filter", async (Filters.FilterApenso filtro, string uri, IApensoValidation validation, IApensoWriter writer, IProcessosReader processosReader, IApensoService service) =>
        {
            logger.Info("Apenso: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Apenso_Filter").WithDisplayName("Filter Apenso");
        group.MapGet("/GetById/{id}", async (int id, string uri, IApensoValidation validation, IApensoWriter writer, IProcessosReader processosReader, IApensoService service, CancellationToken token) =>
        {
            logger.Info("Apenso: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Apenso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Apenso_GetById").WithDisplayName("Get Apenso By Id");
        group.MapPost("/AddAndUpdate", async (Models.Apenso regApenso, string uri, IApensoValidation validation, IApensoWriter writer, IProcessosReader processosReader, IApensoService service) =>
        {
            logger.LogInfo("Apenso", "AddAndUpdate", $"regApenso = {regApenso}", uri);
            var result = await service.AddAndUpdate(regApenso, uri);
            if (result == null)
            {
                logger.LogWarn("Apenso", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Apenso_AddAndUpdate").WithDisplayName("Add or Update Apenso");
        group.MapDelete("/Delete", async (int id, string uri, IApensoValidation validation, IApensoWriter writer, IProcessosReader processosReader, IApensoService service) =>
        {
            logger.LogInfo("Apenso", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Apenso", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Apenso_Delete").WithDisplayName("Delete Apenso");
    }
}