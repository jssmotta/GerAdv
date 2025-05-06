#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProProcuradoresEndpoints
{
    public static IEndpointRouteBuilder MapProProcuradoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProProcuradores").WithTags("ProProcuradores").RequireAuthorization();
        MapProProcuradoresRoutes(group);
        return app;
    }

    private static void MapProProcuradoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProProcuradores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_GetAll").WithDisplayName("Get All ProProcuradores");
        group.MapPost("/Filter", async (Filters.FilterProProcuradores filtro, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            logger.Info("ProProcuradores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_Filter").WithDisplayName("Filter ProProcuradores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service, CancellationToken token) =>
        {
            logger.Info("ProProcuradores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProProcuradores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_GetById").WithDisplayName("Get ProProcuradores By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            logger.Info("ProProcuradores: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProProcuradores found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_GetByName").WithDisplayName("Get ProProcuradores By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProProcuradores? filtro, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            logger.Info("ProProcuradores: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_GetListN").WithDisplayName("Get ProProcuradores List N");
        group.MapPost("/AddAndUpdate", async (Models.ProProcuradores regProProcuradores, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            logger.LogInfo("ProProcuradores", "AddAndUpdate", $"regProProcuradores = {regProProcuradores}", uri);
            var result = await service.AddAndUpdate(regProProcuradores, uri);
            if (result == null)
            {
                logger.LogWarn("ProProcuradores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_AddAndUpdate").WithDisplayName("Add or Update ProProcuradores");
        group.MapDelete("/Delete", async (int id, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            logger.LogInfo("ProProcuradores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProProcuradores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_Delete").WithDisplayName("Delete ProProcuradores");
    }
}