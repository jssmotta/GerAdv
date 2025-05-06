#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProValoresEndpoints
{
    public static IEndpointRouteBuilder MapProValoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProValores").WithTags("ProValores").RequireAuthorization();
        MapProValoresRoutes(group);
        return app;
    }

    private static void MapProValoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProValores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProValores_GetAll").WithDisplayName("Get All ProValores");
        group.MapPost("/Filter", async (Filters.FilterProValores filtro, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            logger.Info("ProValores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProValores_Filter").WithDisplayName("Filter ProValores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service, CancellationToken token) =>
        {
            logger.Info("ProValores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProValores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProValores_GetById").WithDisplayName("Get ProValores By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProValores regProValores, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            logger.LogInfo("ProValores", "AddAndUpdate", $"regProValores = {regProValores}", uri);
            var result = await service.AddAndUpdate(regProValores, uri);
            if (result == null)
            {
                logger.LogWarn("ProValores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProValores_AddAndUpdate").WithDisplayName("Add or Update ProValores");
        group.MapDelete("/Delete", async (int id, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            logger.LogInfo("ProValores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProValores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProValores_Delete").WithDisplayName("Delete ProValores");
    }
}