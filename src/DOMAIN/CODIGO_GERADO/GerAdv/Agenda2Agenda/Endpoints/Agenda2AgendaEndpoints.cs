#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Agenda2AgendaEndpoints
{
    public static IEndpointRouteBuilder MapAgenda2AgendaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Agenda2Agenda").WithTags("Agenda2Agenda").RequireAuthorization();
        MapAgenda2AgendaRoutes(group);
        return app;
    }

    private static void MapAgenda2AgendaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgenda2AgendaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Agenda2Agenda_GetAll").WithDisplayName("Get All Agenda2Agenda");
        group.MapPost("/Filter", async (Filters.FilterAgenda2Agenda filtro, string uri, IAgenda2AgendaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Agenda2Agenda_Filter").WithDisplayName("Filter Agenda2Agenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgenda2AgendaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Agenda2Agenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda2Agenda_GetById").WithDisplayName("Get Agenda2Agenda By Id");
        group.MapPost("/AddAndUpdate", async (Models.Agenda2Agenda regAgenda2Agenda, string uri, IAgenda2AgendaValidation validation, IAgenda2AgendaWriter writer, IAgendaReader agendaReader, IAgenda2AgendaService service) =>
        {
            var result = await service.AddAndUpdate(regAgenda2Agenda, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Agenda2Agenda_AddAndUpdate").WithDisplayName("Add or Update Agenda2Agenda");
        group.MapDelete("/Delete", async (int id, string uri, IAgenda2AgendaValidation validation, IAgenda2AgendaWriter writer, IAgendaReader agendaReader, IAgenda2AgendaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda2Agenda_Delete").WithDisplayName("Delete Agenda2Agenda");
    }
}