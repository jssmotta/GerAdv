#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CidadeEndpoints
{
    public static IEndpointRouteBuilder MapCidadeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Cidade").WithTags("Cidade").RequireAuthorization();
        MapCidadeRoutes(group);
        return app;
    }

    private static void MapCidadeRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICidadeService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Cidade_GetAll").WithDisplayName("Get All Cidade");
        group.MapPost("/Filter", async (Filters.FilterCidade filtro, string uri, ICidadeService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Cidade_Filter").WithDisplayName("Filter Cidade");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICidadeService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Cidade found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cidade_GetById").WithDisplayName("Get Cidade By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterCidade? filtro, string uri, ICidadeService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Cidade_GetListN").WithDisplayName("Get Cidade List N");
        group.MapPost("/AddAndUpdate", async (Models.Cidade regCidade, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            var result = await service.AddAndUpdate(regCidade, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Cidade_AddAndUpdate").WithDisplayName("Add or Update Cidade");
        group.MapDelete("/Delete", async (int id, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cidade_Delete").WithDisplayName("Delete Cidade");
    }
}