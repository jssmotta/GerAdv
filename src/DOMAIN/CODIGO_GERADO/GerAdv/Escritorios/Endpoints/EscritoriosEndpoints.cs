#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EscritoriosEndpoints
{
    public static IEndpointRouteBuilder MapEscritoriosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Escritorios").WithTags("Escritorios").RequireAuthorization();
        MapEscritoriosRoutes(group);
        return app;
    }

    private static void MapEscritoriosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEscritoriosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_GetAll").WithDisplayName("Get All Escritorios");
        group.MapPost("/Filter", async (Filters.FilterEscritorios filtro, string uri, IEscritoriosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_Filter").WithDisplayName("Filter Escritorios");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEscritoriosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Escritorios found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_GetById").WithDisplayName("Get Escritorios By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterEscritorios? filtro, string uri, IEscritoriosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_GetListN").WithDisplayName("Get Escritorios List N");
        group.MapPost("/AddAndUpdate", async (Models.Escritorios regEscritorios, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, ICidadeReader cidadeReader, IEscritoriosService service) =>
        {
            var result = await service.AddAndUpdate(regEscritorios, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_AddAndUpdate").WithDisplayName("Add or Update Escritorios");
        group.MapDelete("/Delete", async (int id, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, ICidadeReader cidadeReader, IEscritoriosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_Delete").WithDisplayName("Delete Escritorios");
    }
}