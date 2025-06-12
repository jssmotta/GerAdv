#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ObjetosEndpoints
{
    public static IEndpointRouteBuilder MapObjetosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Objetos").WithTags("Objetos").RequireAuthorization();
        MapObjetosRoutes(group);
        return app;
    }

    private static void MapObjetosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IObjetosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Objetos_GetAll").WithDisplayName("Get All Objetos");
        group.MapPost("/Filter", async (Filters.FilterObjetos filtro, string uri, IObjetosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Objetos_Filter").WithDisplayName("Filter Objetos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IObjetosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Objetos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_GetById").WithDisplayName("Get Objetos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterObjetos? filtro, string uri, IObjetosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Objetos_GetListN").WithDisplayName("Get Objetos List N");
        group.MapPost("/AddAndUpdate", async (Models.Objetos regObjetos, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            var result = await service.AddAndUpdate(regObjetos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Objetos_AddAndUpdate").WithDisplayName("Add or Update Objetos");
        group.MapDelete("/Delete", async (int id, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_Delete").WithDisplayName("Delete Objetos");
    }
}