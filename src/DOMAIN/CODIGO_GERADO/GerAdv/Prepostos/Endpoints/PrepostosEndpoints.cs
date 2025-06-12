#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PrepostosEndpoints
{
    public static IEndpointRouteBuilder MapPrepostosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Prepostos").WithTags("Prepostos").RequireAuthorization();
        MapPrepostosRoutes(group);
        return app;
    }

    private static void MapPrepostosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPrepostosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_GetAll").WithDisplayName("Get All Prepostos");
        group.MapPost("/Filter", async (Filters.FilterPrepostos filtro, string uri, IPrepostosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_Filter").WithDisplayName("Filter Prepostos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPrepostosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Prepostos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_GetById").WithDisplayName("Get Prepostos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPrepostos? filtro, string uri, IPrepostosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_GetListN").WithDisplayName("Get Prepostos List N");
        group.MapPost("/AddAndUpdate", async (Models.Prepostos regPrepostos, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, ICidadeReader cidadeReader, IPrepostosService service) =>
        {
            var result = await service.AddAndUpdate(regPrepostos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_AddAndUpdate").WithDisplayName("Add or Update Prepostos");
        group.MapDelete("/Delete", async (int id, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, ICidadeReader cidadeReader, IPrepostosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_Delete").WithDisplayName("Delete Prepostos");
    }
}