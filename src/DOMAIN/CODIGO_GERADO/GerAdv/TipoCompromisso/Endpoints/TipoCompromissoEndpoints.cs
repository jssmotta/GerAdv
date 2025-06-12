#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoCompromissoEndpoints
{
    public static IEndpointRouteBuilder MapTipoCompromissoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoCompromisso").WithTags("TipoCompromisso").RequireAuthorization();
        MapTipoCompromissoRoutes(group);
        return app;
    }

    private static void MapTipoCompromissoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoCompromissoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetAll").WithDisplayName("Get All TipoCompromisso");
        group.MapPost("/Filter", async (Filters.FilterTipoCompromisso filtro, string uri, ITipoCompromissoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_Filter").WithDisplayName("Filter TipoCompromisso");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoCompromissoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoCompromisso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetById").WithDisplayName("Get TipoCompromisso By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoCompromisso? filtro, string uri, ITipoCompromissoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoCompromisso_GetListN").WithDisplayName("Get TipoCompromisso List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoCompromisso regTipoCompromisso, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            var result = await service.AddAndUpdate(regTipoCompromisso, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_AddAndUpdate").WithDisplayName("Add or Update TipoCompromisso");
        group.MapDelete("/Delete", async (int id, string uri, ITipoCompromissoValidation validation, ITipoCompromissoWriter writer, ITipoCompromissoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoCompromisso_Delete").WithDisplayName("Delete TipoCompromisso");
    }
}