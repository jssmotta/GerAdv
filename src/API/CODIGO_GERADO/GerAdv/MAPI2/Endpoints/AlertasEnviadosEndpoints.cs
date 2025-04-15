#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AlertasEnviadosEndpoints
{
    public static IEndpointRouteBuilder MapAlertasEnviadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AlertasEnviados").WithTags("AlertasEnviados").RequireAuthorization();
        MapAlertasEnviadosRoutes(group);
        return app;
    }

    private static void MapAlertasEnviadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AlertasEnviados: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AlertasEnviados_GetAll").WithDisplayName("Get All AlertasEnviados");
        group.MapPost("/Filter", async (Filters.FilterAlertasEnviados filtro, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            logger.Info("AlertasEnviados: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AlertasEnviados_Filter").WithDisplayName("Filter AlertasEnviados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service, CancellationToken token) =>
        {
            logger.Info("AlertasEnviados: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AlertasEnviados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_GetById").WithDisplayName("Get AlertasEnviados By Id");
        group.MapPost("/AddAndUpdate", async (Models.AlertasEnviados regAlertasEnviados, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            logger.LogInfo("AlertasEnviados", "AddAndUpdate", $"regAlertasEnviados = {regAlertasEnviados}", uri);
            var result = await service.AddAndUpdate(regAlertasEnviados, uri);
            if (result == null)
            {
                logger.LogWarn("AlertasEnviados", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_AddAndUpdate").WithDisplayName("Add or Update AlertasEnviados");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            logger.LogInfo("AlertasEnviados", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AlertasEnviados", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_GetColumns").WithDisplayName("Get AlertasEnviados Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            logger.LogInfo("AlertasEnviados", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AlertasEnviados", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AlertasEnviados_UpdateColumns").WithDisplayName("Update AlertasEnviados Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            logger.LogInfo("AlertasEnviados", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AlertasEnviados", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_Delete").WithDisplayName("Delete AlertasEnviados");
    }
}