#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ColaboradoresEndpoints
{
    public static IEndpointRouteBuilder MapColaboradoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Colaboradores").WithTags("Colaboradores").RequireAuthorization();
        MapColaboradoresRoutes(group);
        return app;
    }

    private static void MapColaboradoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IColaboradoresService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_GetAll").WithDisplayName("Get All Colaboradores");
        group.MapPost("/Filter", async (Filters.FilterColaboradores filtro, string uri, IColaboradoresService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_Filter").WithDisplayName("Filter Colaboradores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IColaboradoresService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Colaboradores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_GetById").WithDisplayName("Get Colaboradores By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterColaboradores? filtro, string uri, IColaboradoresService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_GetListN").WithDisplayName("Get Colaboradores List N");
        group.MapPost("/AddAndUpdate", async (Models.Colaboradores regColaboradores, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, ICidadeReader cidadeReader, IColaboradoresService service) =>
        {
            var result = await service.AddAndUpdate(regColaboradores, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_AddAndUpdate").WithDisplayName("Add or Update Colaboradores");
        group.MapDelete("/Delete", async (int id, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, ICidadeReader cidadeReader, IColaboradoresService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_Delete").WithDisplayName("Delete Colaboradores");
    }
}