#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoStatusBiuEndpoints
{
    public static IEndpointRouteBuilder MapTipoStatusBiuEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoStatusBiu").WithTags("TipoStatusBiu").RequireAuthorization();
        MapTipoStatusBiuRoutes(group);
        return app;
    }

    private static void MapTipoStatusBiuRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoStatusBiuService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetAll").WithDisplayName("Get All TipoStatusBiu");
        group.MapPost("/Filter", async (Filters.FilterTipoStatusBiu filtro, string uri, ITipoStatusBiuService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_Filter").WithDisplayName("Filter TipoStatusBiu");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoStatusBiuService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoStatusBiu found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetById").WithDisplayName("Get TipoStatusBiu By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoStatusBiu? filtro, string uri, ITipoStatusBiuService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoStatusBiu_GetListN").WithDisplayName("Get TipoStatusBiu List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoStatusBiu regTipoStatusBiu, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            var result = await service.AddAndUpdate(regTipoStatusBiu, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_AddAndUpdate").WithDisplayName("Add or Update TipoStatusBiu");
        group.MapDelete("/Delete", async (int id, string uri, ITipoStatusBiuValidation validation, ITipoStatusBiuWriter writer, ITipoStatusBiuService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoStatusBiu_Delete").WithDisplayName("Delete TipoStatusBiu");
    }
}