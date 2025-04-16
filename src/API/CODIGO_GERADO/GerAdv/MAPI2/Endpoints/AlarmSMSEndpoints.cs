#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AlarmSMSEndpoints
{
    public static IEndpointRouteBuilder MapAlarmSMSEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AlarmSMS").WithTags("AlarmSMS").RequireAuthorization();
        MapAlarmSMSRoutes(group);
        return app;
    }

    private static void MapAlarmSMSRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AlarmSMS: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_GetAll").WithDisplayName("Get All AlarmSMS");
        group.MapPost("/Filter", async (Filters.FilterAlarmSMS filtro, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.Info("AlarmSMS: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_Filter").WithDisplayName("Filter AlarmSMS");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service, CancellationToken token) =>
        {
            logger.Info("AlarmSMS: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AlarmSMS found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_GetById").WithDisplayName("Get AlarmSMS By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.Info("AlarmSMS: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No AlarmSMS found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_GetByName").WithDisplayName("Get AlarmSMS By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAlarmSMS? filtro, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.Info("AlarmSMS: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_GetListN").WithDisplayName("Get AlarmSMS List N");
        group.MapPost("/AddAndUpdate", async (Models.AlarmSMS regAlarmSMS, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.LogInfo("AlarmSMS", "AddAndUpdate", $"regAlarmSMS = {regAlarmSMS}", uri);
            var result = await service.AddAndUpdate(regAlarmSMS, uri);
            if (result == null)
            {
                logger.LogWarn("AlarmSMS", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_AddAndUpdate").WithDisplayName("Add or Update AlarmSMS");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.LogInfo("AlarmSMS", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AlarmSMS", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_GetColumns").WithDisplayName("Get AlarmSMS Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.LogInfo("AlarmSMS", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AlarmSMS", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AlarmSMS_UpdateColumns").WithDisplayName("Update AlarmSMS Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            logger.LogInfo("AlarmSMS", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AlarmSMS", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_Delete").WithDisplayName("Delete AlarmSMS");
    }
}