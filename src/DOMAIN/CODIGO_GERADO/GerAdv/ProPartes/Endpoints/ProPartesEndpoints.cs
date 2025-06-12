#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProPartesEndpoints
{
    public static IEndpointRouteBuilder MapProPartesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProPartes").WithTags("ProPartes").RequireAuthorization();
        MapProPartesRoutes(group);
        return app;
    }

    private static void MapProPartesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProPartesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProPartes_GetAll").WithDisplayName("Get All ProPartes");
        group.MapPost("/Filter", async (Filters.FilterProPartes filtro, string uri, IProPartesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProPartes_Filter").WithDisplayName("Filter ProPartes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProPartesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProPartes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_GetById").WithDisplayName("Get ProPartes By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProPartes regProPartes, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            var result = await service.AddAndUpdate(regProPartes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_AddAndUpdate").WithDisplayName("Add or Update ProPartes");
        group.MapDelete("/Delete", async (int id, string uri, IProPartesValidation validation, IProPartesWriter writer, IProcessosReader processosReader, IProPartesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProPartes_Delete").WithDisplayName("Delete ProPartes");
    }
}