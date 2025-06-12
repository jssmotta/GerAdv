#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TiposAcaoEndpoints
{
    public static IEndpointRouteBuilder MapTiposAcaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TiposAcao").WithTags("TiposAcao").RequireAuthorization();
        MapTiposAcaoRoutes(group);
        return app;
    }

    private static void MapTiposAcaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITiposAcaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_GetAll").WithDisplayName("Get All TiposAcao");
        group.MapPost("/Filter", async (Filters.FilterTiposAcao filtro, string uri, ITiposAcaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_Filter").WithDisplayName("Filter TiposAcao");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITiposAcaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TiposAcao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_GetById").WithDisplayName("Get TiposAcao By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTiposAcao? filtro, string uri, ITiposAcaoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TiposAcao_GetListN").WithDisplayName("Get TiposAcao List N");
        group.MapPost("/AddAndUpdate", async (Models.TiposAcao regTiposAcao, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            var result = await service.AddAndUpdate(regTiposAcao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_AddAndUpdate").WithDisplayName("Add or Update TiposAcao");
        group.MapDelete("/Delete", async (int id, string uri, ITiposAcaoValidation validation, ITiposAcaoWriter writer, ITiposAcaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TiposAcao_Delete").WithDisplayName("Delete TiposAcao");
    }
}