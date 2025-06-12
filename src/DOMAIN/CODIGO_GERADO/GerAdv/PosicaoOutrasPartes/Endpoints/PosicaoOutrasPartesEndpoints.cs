#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PosicaoOutrasPartesEndpoints
{
    public static IEndpointRouteBuilder MapPosicaoOutrasPartesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PosicaoOutrasPartes").WithTags("PosicaoOutrasPartes").RequireAuthorization();
        MapPosicaoOutrasPartesRoutes(group);
        return app;
    }

    private static void MapPosicaoOutrasPartesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPosicaoOutrasPartesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetAll").WithDisplayName("Get All PosicaoOutrasPartes");
        group.MapPost("/Filter", async (Filters.FilterPosicaoOutrasPartes filtro, string uri, IPosicaoOutrasPartesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_Filter").WithDisplayName("Filter PosicaoOutrasPartes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPosicaoOutrasPartesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PosicaoOutrasPartes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetById").WithDisplayName("Get PosicaoOutrasPartes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPosicaoOutrasPartes? filtro, string uri, IPosicaoOutrasPartesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetListN").WithDisplayName("Get PosicaoOutrasPartes List N");
        group.MapPost("/AddAndUpdate", async (Models.PosicaoOutrasPartes regPosicaoOutrasPartes, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            var result = await service.AddAndUpdate(regPosicaoOutrasPartes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_AddAndUpdate").WithDisplayName("Add or Update PosicaoOutrasPartes");
        group.MapDelete("/Delete", async (int id, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_Delete").WithDisplayName("Delete PosicaoOutrasPartes");
    }
}