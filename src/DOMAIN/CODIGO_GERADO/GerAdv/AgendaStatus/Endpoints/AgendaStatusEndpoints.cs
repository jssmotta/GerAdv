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
        group.MapGet("/GetAll", async (int max, string uri, IAgendaStatusService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaStatus_GetAll").WithDisplayName("Get All AgendaStatus");
        group.MapPost("/Filter", async (Filters.FilterAgendaStatus filtro, string uri, IAgendaStatusService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaStatus_Filter").WithDisplayName("Filter AgendaStatus");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaStatusService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regAgendaStatus, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_AddAndUpdate").WithDisplayName("Add or Update AgendaStatus");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaStatusValidation validation, IAgendaStatusWriter writer, IAgendaReader agendaReader, IAgendaStatusService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaStatus_Delete").WithDisplayName("Delete AgendaStatus");
    }
}