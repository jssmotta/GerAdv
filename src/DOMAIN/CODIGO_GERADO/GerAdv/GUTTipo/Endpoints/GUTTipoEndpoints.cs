#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTTipoEndpoints
{
    public static IEndpointRouteBuilder MapGUTTipoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTTipo").WithTags("GUTTipo").RequireAuthorization();
        MapGUTTipoRoutes(group);
        return app;
    }

    private static void MapGUTTipoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTTipoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_GetAll").WithDisplayName("Get All GUTTipo");
        group.MapPost("/Filter", async (Filters.FilterGUTTipo filtro, string uri, IGUTTipoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_Filter").WithDisplayName("Filter GUTTipo");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTTipoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTTipo found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_GetById").WithDisplayName("Get GUTTipo By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTTipo? filtro, string uri, IGUTTipoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTTipo_GetListN").WithDisplayName("Get GUTTipo List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTTipo regGUTTipo, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            var result = await service.AddAndUpdate(regGUTTipo, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_AddAndUpdate").WithDisplayName("Add or Update GUTTipo");
        group.MapDelete("/Delete", async (int id, string uri, IGUTTipoValidation validation, IGUTTipoWriter writer, IGUTTipoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTTipo_Delete").WithDisplayName("Delete GUTTipo");
    }
}