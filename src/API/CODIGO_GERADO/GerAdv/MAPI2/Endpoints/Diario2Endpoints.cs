#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Diario2Endpoints
{
    public static IEndpointRouteBuilder MapDiario2Endpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Diario2").WithTags("Diario2").RequireAuthorization();
        MapDiario2Routes(group);
        return app;
    }

    private static void MapDiario2Routes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Diario2: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Diario2_GetAll").WithDisplayName("Get All Diario2");
        group.MapPost("/Filter", async (Filters.FilterDiario2 filtro, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            logger.Info("Diario2: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Diario2_Filter").WithDisplayName("Filter Diario2");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service, CancellationToken token) =>
        {
            logger.Info("Diario2: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Diario2 found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Diario2_GetById").WithDisplayName("Get Diario2 By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            logger.Info("Diario2: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Diario2 found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Diario2_GetByName").WithDisplayName("Get Diario2 By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterDiario2? filtro, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            logger.Info("Diario2: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Diario2_GetListN").WithDisplayName("Get Diario2 List N");
        group.MapPost("/AddAndUpdate", async (Models.Diario2 regDiario2, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            logger.LogInfo("Diario2", "AddAndUpdate", $"regDiario2 = {regDiario2}", uri);
            var result = await service.AddAndUpdate(regDiario2, uri);
            if (result == null)
            {
                logger.LogWarn("Diario2", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Diario2_AddAndUpdate").WithDisplayName("Add or Update Diario2");
        group.MapDelete("/Delete", async (int id, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            logger.LogInfo("Diario2", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Diario2", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Diario2_Delete").WithDisplayName("Delete Diario2");
    }
}