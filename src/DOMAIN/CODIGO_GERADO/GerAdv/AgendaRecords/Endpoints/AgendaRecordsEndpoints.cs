#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaRecordsEndpoints
{
    public static IEndpointRouteBuilder MapAgendaRecordsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaRecords").WithTags("AgendaRecords").RequireAuthorization();
        MapAgendaRecordsRoutes(group);
        return app;
    }

    private static void MapAgendaRecordsRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaRecordsService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaRecords_GetAll").WithDisplayName("Get All AgendaRecords");
        group.MapPost("/Filter", async (Filters.FilterAgendaRecords filtro, string uri, IAgendaRecordsService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaRecords_Filter").WithDisplayName("Filter AgendaRecords");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaRecordsService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaRecords found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRecords_GetById").WithDisplayName("Get AgendaRecords By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaRecords regAgendaRecords, string uri, IAgendaRecordsValidation validation, IAgendaRecordsWriter writer, IAgendaReader agendaReader, IClientesSociosReader clientessociosReader, IColaboradoresReader colaboradoresReader, IForoReader foroReader, IAgendaRecordsService service) =>
        {
            var result = await service.AddAndUpdate(regAgendaRecords, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaRecords_AddAndUpdate").WithDisplayName("Add or Update AgendaRecords");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaRecordsValidation validation, IAgendaRecordsWriter writer, IAgendaReader agendaReader, IClientesSociosReader clientessociosReader, IColaboradoresReader colaboradoresReader, IForoReader foroReader, IAgendaRecordsService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRecords_Delete").WithDisplayName("Delete AgendaRecords");
    }
}