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
        group.MapGet("/GetAll", async (int max, string uri, IAlarmSMSService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_GetAll").WithDisplayName("Get All AlarmSMS");
        group.MapPost("/Filter", async (Filters.FilterAlarmSMS filtro, string uri, IAlarmSMSService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_Filter").WithDisplayName("Filter AlarmSMS");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlarmSMSService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AlarmSMS found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_GetById").WithDisplayName("Get AlarmSMS By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAlarmSMS? filtro, string uri, IAlarmSMSService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("AlarmSMS_GetListN").WithDisplayName("Get AlarmSMS List N");
        group.MapPost("/AddAndUpdate", async (Models.AlarmSMS regAlarmSMS, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            var result = await service.AddAndUpdate(regAlarmSMS, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_AddAndUpdate").WithDisplayName("Add or Update AlarmSMS");
        group.MapDelete("/Delete", async (int id, string uri, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IAlarmSMSService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlarmSMS_Delete").WithDisplayName("Delete AlarmSMS");
    }
}