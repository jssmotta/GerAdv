#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaStatusEndpoints
{
    public static IEndpointRouteBuilder MapAgendaStatusEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaStatus").WithTags("AgendaStatus").RequireAuthorization();
        MapAgendaStatusRoutes(group);
        return app;
    }

    private static void MapAgendaStatusRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AgendaStatus: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaStatus_GetAll").WithDisplayName("Get All AgendaStatus");
        group.MapPost("/Filter", async (Filters.FilterAgendaStatus filtro, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            logger.Info("AgendaStatus: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaStatus_Filter").WithDisplayName("Filter AgendaStatus");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service, CancellationToken token) =>
        {
            logger.Info("AgendaStatus: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaStatus found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_GetById").WithDisplayName("Get AgendaStatus By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaStatus regAgendaStatus, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            logger.LogInfo("AgendaStatus", "AddAndUpdate", $"regAgendaStatus = {regAgendaStatus}", uri);
            var result = await service.AddAndUpdate(regAgendaStatus, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaStatus", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_AddAndUpdate").WithDisplayName("Add or Update AgendaStatus");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            logger.LogInfo("AgendaStatus", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaStatus", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_GetColumns").WithDisplayName("Get AgendaStatus Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            logger.LogInfo("AgendaStatus", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AgendaStatus", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AgendaStatus_UpdateColumns").WithDisplayName("Update AgendaStatus Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            logger.LogInfo("AgendaStatus", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaStatus", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_Delete").WithDisplayName("Delete AgendaStatus");
    }
}