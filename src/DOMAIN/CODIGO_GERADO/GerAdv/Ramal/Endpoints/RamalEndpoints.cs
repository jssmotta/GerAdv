#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RamalEndpoints
{
    public static IEndpointRouteBuilder MapRamalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Ramal").WithTags("Ramal").RequireAuthorization();
        MapRamalRoutes(group);
        return app;
    }

    private static void MapRamalRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRamalService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Ramal_GetAll").WithDisplayName("Get All Ramal");
        group.MapPost("/Filter", async (Filters.FilterRamal filtro, string uri, IRamalService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Ramal_Filter").WithDisplayName("Filter Ramal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRamalService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Ramal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ramal_GetById").WithDisplayName("Get Ramal By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterRamal? filtro, string uri, IRamalService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Ramal_GetListN").WithDisplayName("Get Ramal List N");
        group.MapPost("/AddAndUpdate", async (Models.Ramal regRamal, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            var result = await service.AddAndUpdate(regRamal, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Ramal_AddAndUpdate").WithDisplayName("Add or Update Ramal");
        group.MapDelete("/Delete", async (int id, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ramal_Delete").WithDisplayName("Delete Ramal");
    }
}