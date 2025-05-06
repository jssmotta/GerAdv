#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProDespesasEndpoints
{
    public static IEndpointRouteBuilder MapProDespesasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProDespesas").WithTags("ProDespesas").RequireAuthorization();
        MapProDespesasRoutes(group);
        return app;
    }

    private static void MapProDespesasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProDespesas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProDespesas_GetAll").WithDisplayName("Get All ProDespesas");
        group.MapPost("/Filter", async (Filters.FilterProDespesas filtro, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            logger.Info("ProDespesas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProDespesas_Filter").WithDisplayName("Filter ProDespesas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service, CancellationToken token) =>
        {
            logger.Info("ProDespesas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProDespesas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_GetById").WithDisplayName("Get ProDespesas By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProDespesas regProDespesas, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            logger.LogInfo("ProDespesas", "AddAndUpdate", $"regProDespesas = {regProDespesas}", uri);
            var result = await service.AddAndUpdate(regProDespesas, uri);
            if (result == null)
            {
                logger.LogWarn("ProDespesas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_AddAndUpdate").WithDisplayName("Add or Update ProDespesas");
        group.MapDelete("/Delete", async (int id, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            logger.LogInfo("ProDespesas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProDespesas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_Delete").WithDisplayName("Delete ProDespesas");
    }
}