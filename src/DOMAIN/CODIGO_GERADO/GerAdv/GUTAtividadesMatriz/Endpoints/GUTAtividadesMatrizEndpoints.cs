#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTAtividadesMatrizEndpoints
{
    public static IEndpointRouteBuilder MapGUTAtividadesMatrizEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTAtividadesMatriz").WithTags("GUTAtividadesMatriz").RequireAuthorization();
        MapGUTAtividadesMatrizRoutes(group);
        return app;
    }

    private static void MapGUTAtividadesMatrizRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTAtividadesMatrizService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_GetAll").WithDisplayName("Get All GUTAtividadesMatriz");
        group.MapPost("/Filter", async (Filters.FilterGUTAtividadesMatriz filtro, string uri, IGUTAtividadesMatrizService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_Filter").WithDisplayName("Filter GUTAtividadesMatriz");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTAtividadesMatrizService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTAtividadesMatriz found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_GetById").WithDisplayName("Get GUTAtividadesMatriz By Id");
        group.MapPost("/AddAndUpdate", async (Models.GUTAtividadesMatriz regGUTAtividadesMatriz, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            var result = await service.AddAndUpdate(regGUTAtividadesMatriz, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_AddAndUpdate").WithDisplayName("Add or Update GUTAtividadesMatriz");
        group.MapDelete("/Delete", async (int id, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_Delete").WithDisplayName("Delete GUTAtividadesMatriz");
    }
}