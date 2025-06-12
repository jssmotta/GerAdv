#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RegimeTributacaoEndpoints
{
    public static IEndpointRouteBuilder MapRegimeTributacaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/RegimeTributacao").WithTags("RegimeTributacao").RequireAuthorization();
        MapRegimeTributacaoRoutes(group);
        return app;
    }

    private static void MapRegimeTributacaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRegimeTributacaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetAll").WithDisplayName("Get All RegimeTributacao");
        group.MapPost("/Filter", async (Filters.FilterRegimeTributacao filtro, string uri, IRegimeTributacaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_Filter").WithDisplayName("Filter RegimeTributacao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRegimeTributacaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No RegimeTributacao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetById").WithDisplayName("Get RegimeTributacao By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterRegimeTributacao? filtro, string uri, IRegimeTributacaoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("RegimeTributacao_GetListN").WithDisplayName("Get RegimeTributacao List N");
        group.MapPost("/AddAndUpdate", async (Models.RegimeTributacao regRegimeTributacao, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            var result = await service.AddAndUpdate(regRegimeTributacao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_AddAndUpdate").WithDisplayName("Add or Update RegimeTributacao");
        group.MapDelete("/Delete", async (int id, string uri, IRegimeTributacaoValidation validation, IRegimeTributacaoWriter writer, IRegimeTributacaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("RegimeTributacao_Delete").WithDisplayName("Delete RegimeTributacao");
    }
}