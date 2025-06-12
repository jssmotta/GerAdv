#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGruposAgendaEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGruposAgendaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGruposAgenda").WithTags("OperadorGruposAgenda").RequireAuthorization();
        MapOperadorGruposAgendaRoutes(group);
        return app;
    }

    private static void MapOperadorGruposAgendaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGruposAgendaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetAll").WithDisplayName("Get All OperadorGruposAgenda");
        group.MapPost("/Filter", async (Filters.FilterOperadorGruposAgenda filtro, string uri, IOperadorGruposAgendaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_Filter").WithDisplayName("Filter OperadorGruposAgenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGruposAgendaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGruposAgenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetById").WithDisplayName("Get OperadorGruposAgenda By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorGruposAgenda? filtro, string uri, IOperadorGruposAgendaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetListN").WithDisplayName("Get OperadorGruposAgenda List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGruposAgenda regOperadorGruposAgenda, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            var result = await service.AddAndUpdate(regOperadorGruposAgenda, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_AddAndUpdate").WithDisplayName("Add or Update OperadorGruposAgenda");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_Delete").WithDisplayName("Delete OperadorGruposAgenda");
    }
}