#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTMatrizEndpoints
{
    public static IEndpointRouteBuilder MapGUTMatrizEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTMatriz").WithTags("GUTMatriz").RequireAuthorization();
        MapGUTMatrizRoutes(group);
        return app;
    }

    private static void MapGUTMatrizRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTMatrizService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_GetAll").WithDisplayName("Get All GUTMatriz");
        group.MapPost("/Filter", async (Filters.FilterGUTMatriz filtro, string uri, IGUTMatrizService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_Filter").WithDisplayName("Filter GUTMatriz");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTMatrizService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTMatriz found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_GetById").WithDisplayName("Get GUTMatriz By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTMatriz? filtro, string uri, IGUTMatrizService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTMatriz_GetListN").WithDisplayName("Get GUTMatriz List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTMatriz regGUTMatriz, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            var result = await service.AddAndUpdate(regGUTMatriz, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_AddAndUpdate").WithDisplayName("Add or Update GUTMatriz");
        group.MapDelete("/Delete", async (int id, string uri, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTMatrizService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTMatriz_Delete").WithDisplayName("Delete GUTMatriz");
    }
}