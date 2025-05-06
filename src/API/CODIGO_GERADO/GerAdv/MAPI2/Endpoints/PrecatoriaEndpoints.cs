#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PrecatoriaEndpoints
{
    public static IEndpointRouteBuilder MapPrecatoriaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Precatoria").WithTags("Precatoria").RequireAuthorization();
        MapPrecatoriaRoutes(group);
        return app;
    }

    private static void MapPrecatoriaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPrecatoriaValidation validation, IPrecatoriaWriter writer, IProcessosReader processosReader, IPrecatoriaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Precatoria: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Precatoria_GetAll").WithDisplayName("Get All Precatoria");
        group.MapPost("/Filter", async (Filters.FilterPrecatoria filtro, string uri, IPrecatoriaValidation validation, IPrecatoriaWriter writer, IProcessosReader processosReader, IPrecatoriaService service) =>
        {
            logger.Info("Precatoria: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Precatoria_Filter").WithDisplayName("Filter Precatoria");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPrecatoriaValidation validation, IPrecatoriaWriter writer, IProcessosReader processosReader, IPrecatoriaService service, CancellationToken token) =>
        {
            logger.Info("Precatoria: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Precatoria found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Precatoria_GetById").WithDisplayName("Get Precatoria By Id");
        group.MapPost("/AddAndUpdate", async (Models.Precatoria regPrecatoria, string uri, IPrecatoriaValidation validation, IPrecatoriaWriter writer, IProcessosReader processosReader, IPrecatoriaService service) =>
        {
            logger.LogInfo("Precatoria", "AddAndUpdate", $"regPrecatoria = {regPrecatoria}", uri);
            var result = await service.AddAndUpdate(regPrecatoria, uri);
            if (result == null)
            {
                logger.LogWarn("Precatoria", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Precatoria_AddAndUpdate").WithDisplayName("Add or Update Precatoria");
        group.MapDelete("/Delete", async (int id, string uri, IPrecatoriaValidation validation, IPrecatoriaWriter writer, IProcessosReader processosReader, IPrecatoriaService service) =>
        {
            logger.LogInfo("Precatoria", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Precatoria", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Precatoria_Delete").WithDisplayName("Delete Precatoria");
    }
}