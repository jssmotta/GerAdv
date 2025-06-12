#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoEnderecoSistemaEndpoints
{
    public static IEndpointRouteBuilder MapTipoEnderecoSistemaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoEnderecoSistema").WithTags("TipoEnderecoSistema").RequireAuthorization();
        MapTipoEnderecoSistemaRoutes(group);
        return app;
    }

    private static void MapTipoEnderecoSistemaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoEnderecoSistemaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetAll").WithDisplayName("Get All TipoEnderecoSistema");
        group.MapPost("/Filter", async (Filters.FilterTipoEnderecoSistema filtro, string uri, ITipoEnderecoSistemaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_Filter").WithDisplayName("Filter TipoEnderecoSistema");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEnderecoSistemaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEnderecoSistema found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetById").WithDisplayName("Get TipoEnderecoSistema By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEnderecoSistema? filtro, string uri, ITipoEnderecoSistemaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetListN").WithDisplayName("Get TipoEnderecoSistema List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEnderecoSistema regTipoEnderecoSistema, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            var result = await service.AddAndUpdate(regTipoEnderecoSistema, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_AddAndUpdate").WithDisplayName("Add or Update TipoEnderecoSistema");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_Delete").WithDisplayName("Delete TipoEnderecoSistema");
    }
}