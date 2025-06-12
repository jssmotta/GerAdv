#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PreClientesEndpoints
{
    public static IEndpointRouteBuilder MapPreClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PreClientes").WithTags("PreClientes").RequireAuthorization();
        MapPreClientesRoutes(group);
        return app;
    }

    private static void MapPreClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPreClientesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_GetAll").WithDisplayName("Get All PreClientes");
        group.MapPost("/Filter", async (Filters.FilterPreClientes filtro, string uri, IPreClientesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_Filter").WithDisplayName("Filter PreClientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPreClientesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PreClientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_GetById").WithDisplayName("Get PreClientes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPreClientes? filtro, string uri, IPreClientesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_GetListN").WithDisplayName("Get PreClientes List N");
        group.MapPost("/AddAndUpdate", async (Models.PreClientes regPreClientes, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IPreClientesService service) =>
        {
            var result = await service.AddAndUpdate(regPreClientes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_AddAndUpdate").WithDisplayName("Add or Update PreClientes");
        group.MapDelete("/Delete", async (int id, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IPreClientesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_Delete").WithDisplayName("Delete PreClientes");
    }
}