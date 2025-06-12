#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusTarefasEndpoints
{
    public static IEndpointRouteBuilder MapStatusTarefasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusTarefas").WithTags("StatusTarefas").RequireAuthorization();
        MapStatusTarefasRoutes(group);
        return app;
    }

    private static void MapStatusTarefasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusTarefasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_GetAll").WithDisplayName("Get All StatusTarefas");
        group.MapPost("/Filter", async (Filters.FilterStatusTarefas filtro, string uri, IStatusTarefasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_Filter").WithDisplayName("Filter StatusTarefas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusTarefasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusTarefas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_GetById").WithDisplayName("Get StatusTarefas By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusTarefas? filtro, string uri, IStatusTarefasService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusTarefas_GetListN").WithDisplayName("Get StatusTarefas List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusTarefas regStatusTarefas, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            var result = await service.AddAndUpdate(regStatusTarefas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_AddAndUpdate").WithDisplayName("Add or Update StatusTarefas");
        group.MapDelete("/Delete", async (int id, string uri, IStatusTarefasValidation validation, IStatusTarefasWriter writer, IStatusTarefasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusTarefas_Delete").WithDisplayName("Delete StatusTarefas");
    }
}