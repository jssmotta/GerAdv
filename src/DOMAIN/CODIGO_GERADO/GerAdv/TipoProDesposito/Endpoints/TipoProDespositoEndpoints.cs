#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoProDespositoEndpoints
{
    public static IEndpointRouteBuilder MapTipoProDespositoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoProDesposito").WithTags("TipoProDesposito").RequireAuthorization();
        MapTipoProDespositoRoutes(group);
        return app;
    }

    private static void MapTipoProDespositoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoProDespositoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetAll").WithDisplayName("Get All TipoProDesposito");
        group.MapPost("/Filter", async (Filters.FilterTipoProDesposito filtro, string uri, ITipoProDespositoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_Filter").WithDisplayName("Filter TipoProDesposito");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoProDespositoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoProDesposito found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetById").WithDisplayName("Get TipoProDesposito By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoProDesposito? filtro, string uri, ITipoProDespositoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoProDesposito_GetListN").WithDisplayName("Get TipoProDesposito List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoProDesposito regTipoProDesposito, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            var result = await service.AddAndUpdate(regTipoProDesposito, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_AddAndUpdate").WithDisplayName("Add or Update TipoProDesposito");
        group.MapDelete("/Delete", async (int id, string uri, ITipoProDespositoValidation validation, ITipoProDespositoWriter writer, ITipoProDespositoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoProDesposito_Delete").WithDisplayName("Delete TipoProDesposito");
    }
}