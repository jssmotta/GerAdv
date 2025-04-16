#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessosParadosEndpoints
{
    public static IEndpointRouteBuilder MapProcessosParadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessosParados").WithTags("ProcessosParados").RequireAuthorization();
        MapProcessosParadosRoutes(group);
        return app;
    }

    private static void MapProcessosParadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessosParados: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessosParados_GetAll").WithDisplayName("Get All ProcessosParados");
        group.MapPost("/Filter", async (Filters.FilterProcessosParados filtro, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            logger.Info("ProcessosParados: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessosParados_Filter").WithDisplayName("Filter ProcessosParados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service, CancellationToken token) =>
        {
            logger.Info("ProcessosParados: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessosParados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_GetById").WithDisplayName("Get ProcessosParados By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProcessosParados regProcessosParados, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            logger.LogInfo("ProcessosParados", "AddAndUpdate", $"regProcessosParados = {regProcessosParados}", uri);
            var result = await service.AddAndUpdate(regProcessosParados, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosParados", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_AddAndUpdate").WithDisplayName("Add or Update ProcessosParados");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            logger.LogInfo("ProcessosParados", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosParados", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_GetColumns").WithDisplayName("Get ProcessosParados Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            logger.LogInfo("ProcessosParados", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProcessosParados", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProcessosParados_UpdateColumns").WithDisplayName("Update ProcessosParados Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            logger.LogInfo("ProcessosParados", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosParados", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_Delete").WithDisplayName("Delete ProcessosParados");
    }
}