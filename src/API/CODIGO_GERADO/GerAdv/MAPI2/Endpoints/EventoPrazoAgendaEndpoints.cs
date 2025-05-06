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
        group.MapGet("/GetAll", async (int max, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("EventoPrazoAgenda: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetAll").WithDisplayName("Get All EventoPrazoAgenda");
        group.MapPost("/Filter", async (Filters.FilterEventoPrazoAgenda filtro, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            logger.Info("EventoPrazoAgenda: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_Filter").WithDisplayName("Filter EventoPrazoAgenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service, CancellationToken token) =>
        {
            logger.Info("EventoPrazoAgenda: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EventoPrazoAgenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetById").WithDisplayName("Get EventoPrazoAgenda By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            logger.Info("EventoPrazoAgenda: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No EventoPrazoAgenda found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetByName").WithDisplayName("Get EventoPrazoAgenda By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterEventoPrazoAgenda? filtro, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            logger.Info("EventoPrazoAgenda: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_GetListN").WithDisplayName("Get EventoPrazoAgenda List N");
        group.MapPost("/AddAndUpdate", async (Models.EventoPrazoAgenda regEventoPrazoAgenda, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            logger.LogInfo("EventoPrazoAgenda", "AddAndUpdate", $"regEventoPrazoAgenda = {regEventoPrazoAgenda}", uri);
            var result = await service.AddAndUpdate(regEventoPrazoAgenda, uri);
            if (result == null)
            {
                logger.LogWarn("EventoPrazoAgenda", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_AddAndUpdate").WithDisplayName("Add or Update EventoPrazoAgenda");
        group.MapDelete("/Delete", async (int id, string uri, IEventoPrazoAgendaValidation validation, IEventoPrazoAgendaWriter writer, IEventoPrazoAgendaService service) =>
        {
            logger.LogInfo("EventoPrazoAgenda", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("EventoPrazoAgenda", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EventoPrazoAgenda_Delete").WithDisplayName("Delete EventoPrazoAgenda");
    }
}