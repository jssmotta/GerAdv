#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EventoPrazoAgendaEndpoints
{
    public static IEndpointRouteBuilder MapEventoPrazoAgendaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EventoPrazoAgenda").WithTags("EventoPrazoAgenda").RequireAuthorization();
        MapEventoPrazoAgendaRoutes(group);
        return app;
    }

    private static void MapEventoPrazoAgendaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEventoPrazoAgendaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetAll").WithDisplayName("Get All EventoPrazoAgenda");
        group.MapPost("/Filter", async (Filters.FilterEventoPrazoAgenda filtro, string uri, IEventoPrazoAgendaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_Filter").WithDisplayName("Filter EventoPrazoAgenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEventoPrazoAgendaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EventoPrazoAgenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetById").WithDisplayName("Get EventoPrazoAgenda By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterEventoPrazoAgenda? filtro, string uri, IEventoPrazoAgendaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetListN").WithDisplayName("Get EventoPrazoAgenda List N");
        group.MapPost("/AddAndUpdate", async (Models.EventoPrazoAgenda regEventoPrazoAgenda, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            var result = await service.AddAndUpdate(regEventoPrazoAgenda, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_AddAndUpdate").WithDisplayName("Add or Update EventoPrazoAgenda");
        group.MapDelete("/Delete", async (int id, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_Delete").WithDisplayName("Delete EventoPrazoAgenda");
    }
}