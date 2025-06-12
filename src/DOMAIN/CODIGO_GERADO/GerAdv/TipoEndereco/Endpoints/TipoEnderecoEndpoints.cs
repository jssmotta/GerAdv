#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoEnderecoEndpoints
{
    public static IEndpointRouteBuilder MapTipoEnderecoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoEndereco").WithTags("TipoEndereco").RequireAuthorization();
        MapTipoEnderecoRoutes(group);
        return app;
    }

    private static void MapTipoEnderecoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoEnderecoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_GetAll").WithDisplayName("Get All TipoEndereco");
        group.MapPost("/Filter", async (Filters.FilterTipoEndereco filtro, string uri, ITipoEnderecoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_Filter").WithDisplayName("Filter TipoEndereco");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEnderecoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEndereco found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_GetById").WithDisplayName("Get TipoEndereco By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEndereco? filtro, string uri, ITipoEnderecoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_GetListN").WithDisplayName("Get TipoEndereco List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEndereco regTipoEndereco, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            var result = await service.AddAndUpdate(regTipoEndereco, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_AddAndUpdate").WithDisplayName("Add or Update TipoEndereco");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_Delete").WithDisplayName("Delete TipoEndereco");
    }
}