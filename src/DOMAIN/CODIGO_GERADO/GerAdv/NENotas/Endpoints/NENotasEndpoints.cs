#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NENotasEndpoints
{
    public static IEndpointRouteBuilder MapNENotasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NENotas").WithTags("NENotas").RequireAuthorization();
        MapNENotasRoutes(group);
        return app;
    }

    private static void MapNENotasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INENotasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NENotas_GetAll").WithDisplayName("Get All NENotas");
        group.MapPost("/Filter", async (Filters.FilterNENotas filtro, string uri, INENotasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NENotas_Filter").WithDisplayName("Filter NENotas");
        group.MapGet("/GetById/{id}", async (int id, string uri, INENotasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NENotas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NENotas_GetById").WithDisplayName("Get NENotas By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterNENotas? filtro, string uri, INENotasService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("NENotas_GetListN").WithDisplayName("Get NENotas List N");
        group.MapPost("/AddAndUpdate", async (Models.NENotas regNENotas, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            var result = await service.AddAndUpdate(regNENotas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NENotas_AddAndUpdate").WithDisplayName("Add or Update NENotas");
        group.MapDelete("/Delete", async (int id, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NENotas_Delete").WithDisplayName("Delete NENotas");
    }
}