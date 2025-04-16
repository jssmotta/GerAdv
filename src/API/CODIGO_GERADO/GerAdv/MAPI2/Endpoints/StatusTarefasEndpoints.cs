#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusTarefasEndpoints
{
    public static IEndpointRouteBuilder MapStatusTarefasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusTarefas").WithTags("StatusTarefas").RequireAuthorization();
        MapStatusTarefasRoutes(group);
        return app;
    }

    private static void MapStatusTarefasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("StatusTarefas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_GetAll").WithDisplayName("Get All StatusTarefas");
        group.MapPost("/Filter", async (Filters.FilterStatusTarefas filtro, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.Info("StatusTarefas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_Filter").WithDisplayName("Filter StatusTarefas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service, CancellationToken token) =>
        {
            logger.Info("StatusTarefas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusTarefas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_GetById").WithDisplayName("Get StatusTarefas By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.Info("StatusTarefas: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No StatusTarefas found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_GetByName").WithDisplayName("Get StatusTarefas By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusTarefas? filtro, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.Info("StatusTarefas: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_GetListN").WithDisplayName("Get StatusTarefas List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusTarefas regStatusTarefas, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.LogInfo("StatusTarefas", "AddAndUpdate", $"regStatusTarefas = {regStatusTarefas}", uri);
            var result = await service.AddAndUpdate(regStatusTarefas, uri);
            if (result == null)
            {
                logger.LogWarn("StatusTarefas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_AddAndUpdate").WithDisplayName("Add or Update StatusTarefas");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.LogInfo("StatusTarefas", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("StatusTarefas", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_GetColumns").WithDisplayName("Get StatusTarefas Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.LogInfo("StatusTarefas", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("StatusTarefas", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("StatusTarefas_UpdateColumns").WithDisplayName("Update StatusTarefas Columns");
        group.MapDelete("/Delete", async (int id, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            logger.LogInfo("StatusTarefas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("StatusTarefas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_Delete").WithDisplayName("Delete StatusTarefas");
    }
}