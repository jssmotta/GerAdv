#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PenhoraEndpoints
{
    public static IEndpointRouteBuilder MapPenhoraEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Penhora").WithTags("Penhora").RequireAuthorization();
        MapPenhoraRoutes(group);
        return app;
    }

    private static void MapPenhoraRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Penhora: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Penhora_GetAll").WithDisplayName("Get All Penhora");
        group.MapPost("/Filter", async (Filters.FilterPenhora filtro, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            logger.Info("Penhora: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Penhora_Filter").WithDisplayName("Filter Penhora");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service, CancellationToken token) =>
        {
            logger.Info("Penhora: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Penhora found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Penhora_GetById").WithDisplayName("Get Penhora By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            logger.Info("Penhora: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Penhora found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Penhora_GetByName").WithDisplayName("Get Penhora By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPenhora? filtro, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            logger.Info("Penhora: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Penhora_GetListN").WithDisplayName("Get Penhora List N");
        group.MapPost("/AddAndUpdate", async (Models.Penhora regPenhora, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            logger.LogInfo("Penhora", "AddAndUpdate", $"regPenhora = {regPenhora}", uri);
            var result = await service.AddAndUpdate(regPenhora, uri);
            if (result == null)
            {
                logger.LogWarn("Penhora", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Penhora_AddAndUpdate").WithDisplayName("Add or Update Penhora");
        group.MapDelete("/Delete", async (int id, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            logger.LogInfo("Penhora", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Penhora", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Penhora_Delete").WithDisplayName("Delete Penhora");
    }
}