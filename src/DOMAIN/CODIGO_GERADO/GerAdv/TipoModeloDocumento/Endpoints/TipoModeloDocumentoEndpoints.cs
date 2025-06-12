#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoModeloDocumentoEndpoints
{
    public static IEndpointRouteBuilder MapTipoModeloDocumentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoModeloDocumento").WithTags("TipoModeloDocumento").RequireAuthorization();
        MapTipoModeloDocumentoRoutes(group);
        return app;
    }

    private static void MapTipoModeloDocumentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoModeloDocumentoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetAll").WithDisplayName("Get All TipoModeloDocumento");
        group.MapPost("/Filter", async (Filters.FilterTipoModeloDocumento filtro, string uri, ITipoModeloDocumentoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_Filter").WithDisplayName("Filter TipoModeloDocumento");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoModeloDocumentoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoModeloDocumento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetById").WithDisplayName("Get TipoModeloDocumento By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoModeloDocumento? filtro, string uri, ITipoModeloDocumentoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetListN").WithDisplayName("Get TipoModeloDocumento List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoModeloDocumento regTipoModeloDocumento, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            var result = await service.AddAndUpdate(regTipoModeloDocumento, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_AddAndUpdate").WithDisplayName("Add or Update TipoModeloDocumento");
        group.MapDelete("/Delete", async (int id, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_Delete").WithDisplayName("Delete TipoModeloDocumento");
    }
}