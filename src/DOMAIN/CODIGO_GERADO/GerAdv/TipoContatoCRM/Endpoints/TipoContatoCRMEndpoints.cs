#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoContatoCRMEndpoints
{
    public static IEndpointRouteBuilder MapTipoContatoCRMEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoContatoCRM").WithTags("TipoContatoCRM").RequireAuthorization();
        MapTipoContatoCRMRoutes(group);
        return app;
    }

    private static void MapTipoContatoCRMRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoContatoCRMService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetAll").WithDisplayName("Get All TipoContatoCRM");
        group.MapPost("/Filter", async (Filters.FilterTipoContatoCRM filtro, string uri, ITipoContatoCRMService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_Filter").WithDisplayName("Filter TipoContatoCRM");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoContatoCRMService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoContatoCRM found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetById").WithDisplayName("Get TipoContatoCRM By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoContatoCRM? filtro, string uri, ITipoContatoCRMService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetListN").WithDisplayName("Get TipoContatoCRM List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoContatoCRM regTipoContatoCRM, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            var result = await service.AddAndUpdate(regTipoContatoCRM, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_AddAndUpdate").WithDisplayName("Add or Update TipoContatoCRM");
        group.MapDelete("/Delete", async (int id, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_Delete").WithDisplayName("Delete TipoContatoCRM");
    }
}