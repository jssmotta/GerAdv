#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProPartesEndpoints
{
    public static IEndpointRouteBuilder MapProPartesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProPartes").WithTags("ProPartes").RequireAuthorization();
        MapProPartesRoutes(group);
        return app;
    }

    private static void MapProPartesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProPartes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProPartes_GetAll").WithDisplayName("Get All ProPartes");
        group.MapPost("/Filter", async (Filters.FilterProPartes filtro, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            logger.Info("ProPartes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProPartes_Filter").WithDisplayName("Filter ProPartes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service, CancellationToken token) =>
        {
            logger.Info("ProPartes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProPartes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_GetById").WithDisplayName("Get ProPartes By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProPartes regProPartes, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            logger.LogInfo("ProPartes", "AddAndUpdate", $"regProPartes = {regProPartes}", uri);
            var result = await service.AddAndUpdate(regProPartes, uri);
            if (result == null)
            {
                logger.LogWarn("ProPartes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_AddAndUpdate").WithDisplayName("Add or Update ProPartes");
        group.MapDelete("/Delete", async (int id, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            logger.LogInfo("ProPartes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProPartes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_Delete").WithDisplayName("Delete ProPartes");
    }
}