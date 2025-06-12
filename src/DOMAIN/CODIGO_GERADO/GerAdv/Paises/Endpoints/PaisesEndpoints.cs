#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PaisesEndpoints
{
    public static IEndpointRouteBuilder MapPaisesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Paises").WithTags("Paises").RequireAuthorization();
        MapPaisesRoutes(group);
        return app;
    }

    private static void MapPaisesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPaisesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Paises_GetAll").WithDisplayName("Get All Paises");
        group.MapPost("/Filter", async (Filters.FilterPaises filtro, string uri, IPaisesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Paises_Filter").WithDisplayName("Filter Paises");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPaisesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Paises found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Paises_GetById").WithDisplayName("Get Paises By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPaises? filtro, string uri, IPaisesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Paises_GetListN").WithDisplayName("Get Paises List N");
        group.MapPost("/AddAndUpdate", async (Models.Paises regPaises, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            var result = await service.AddAndUpdate(regPaises, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Paises_AddAndUpdate").WithDisplayName("Add or Update Paises");
        group.MapDelete("/Delete", async (int id, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Paises_Delete").WithDisplayName("Delete Paises");
    }
}