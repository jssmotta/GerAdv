#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTAtividadesEndpoints
{
    public static IEndpointRouteBuilder MapGUTAtividadesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTAtividades").WithTags("GUTAtividades").RequireAuthorization();
        MapGUTAtividadesRoutes(group);
        return app;
    }

    private static void MapGUTAtividadesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTAtividadesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_GetAll").WithDisplayName("Get All GUTAtividades");
        group.MapPost("/Filter", async (Filters.FilterGUTAtividades filtro, string uri, IGUTAtividadesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_Filter").WithDisplayName("Filter GUTAtividades");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTAtividadesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTAtividades found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_GetById").WithDisplayName("Get GUTAtividades By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTAtividades? filtro, string uri, IGUTAtividadesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_GetListN").WithDisplayName("Get GUTAtividades List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTAtividades regGUTAtividades, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            var result = await service.AddAndUpdate(regGUTAtividades, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_AddAndUpdate").WithDisplayName("Add or Update GUTAtividades");
        group.MapDelete("/Delete", async (int id, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_Delete").WithDisplayName("Delete GUTAtividades");
    }
}