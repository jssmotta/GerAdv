#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class BensMateriaisEndpoints
{
    public static IEndpointRouteBuilder MapBensMateriaisEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/BensMateriais").WithTags("BensMateriais").RequireAuthorization();
        MapBensMateriaisRoutes(group);
        return app;
    }

    private static void MapBensMateriaisRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IBensMateriaisService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_GetAll").WithDisplayName("Get All BensMateriais");
        group.MapPost("/Filter", async (Filters.FilterBensMateriais filtro, string uri, IBensMateriaisService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_Filter").WithDisplayName("Filter BensMateriais");
        group.MapGet("/GetById/{id}", async (int id, string uri, IBensMateriaisService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No BensMateriais found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_GetById").WithDisplayName("Get BensMateriais By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterBensMateriais? filtro, string uri, IBensMateriaisService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_GetListN").WithDisplayName("Get BensMateriais List N");
        group.MapPost("/AddAndUpdate", async (Models.BensMateriais regBensMateriais, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, ICidadeReader cidadeReader, IBensMateriaisService service) =>
        {
            var result = await service.AddAndUpdate(regBensMateriais, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_AddAndUpdate").WithDisplayName("Add or Update BensMateriais");
        group.MapDelete("/Delete", async (int id, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, ICidadeReader cidadeReader, IBensMateriaisService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_Delete").WithDisplayName("Delete BensMateriais");
    }
}