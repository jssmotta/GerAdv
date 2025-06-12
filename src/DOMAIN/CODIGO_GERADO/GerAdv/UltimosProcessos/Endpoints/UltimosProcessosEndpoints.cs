#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class UltimosProcessosEndpoints
{
    public static IEndpointRouteBuilder MapUltimosProcessosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/UltimosProcessos").WithTags("UltimosProcessos").RequireAuthorization();
        MapUltimosProcessosRoutes(group);
        return app;
    }

    private static void MapUltimosProcessosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IUltimosProcessosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("UltimosProcessos_GetAll").WithDisplayName("Get All UltimosProcessos");
        group.MapPost("/Filter", async (Filters.FilterUltimosProcessos filtro, string uri, IUltimosProcessosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("UltimosProcessos_Filter").WithDisplayName("Filter UltimosProcessos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IUltimosProcessosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No UltimosProcessos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UltimosProcessos_GetById").WithDisplayName("Get UltimosProcessos By Id");
        group.MapPost("/AddAndUpdate", async (Models.UltimosProcessos regUltimosProcessos, string uri, IUltimosProcessosValidation validation, IUltimosProcessosWriter writer, IProcessosReader processosReader, IUltimosProcessosService service) =>
        {
            var result = await service.AddAndUpdate(regUltimosProcessos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("UltimosProcessos_AddAndUpdate").WithDisplayName("Add or Update UltimosProcessos");
        group.MapDelete("/Delete", async (int id, string uri, IUltimosProcessosValidation validation, IUltimosProcessosWriter writer, IProcessosReader processosReader, IUltimosProcessosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UltimosProcessos_Delete").WithDisplayName("Delete UltimosProcessos");
    }
}