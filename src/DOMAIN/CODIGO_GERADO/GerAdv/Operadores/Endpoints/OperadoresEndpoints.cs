#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadoresEndpoints
{
    public static IEndpointRouteBuilder MapOperadoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Operadores").WithTags("Operadores").RequireAuthorization();
        MapOperadoresRoutes(group);
        return app;
    }

    private static void MapOperadoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadoresService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Operadores_GetAll").WithDisplayName("Get All Operadores");
        group.MapPost("/Filter", async (Filters.FilterOperadores filtro, string uri, IOperadoresService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Operadores_Filter").WithDisplayName("Filter Operadores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadoresService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Operadores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operadores_GetById").WithDisplayName("Get Operadores By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadores? filtro, string uri, IOperadoresService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Operadores_GetListN").WithDisplayName("Get Operadores List N");
        group.MapPost("/AddAndUpdate", async (Models.Operadores regOperadores, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            var result = await service.AddAndUpdate(regOperadores, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Operadores_AddAndUpdate").WithDisplayName("Add or Update Operadores");
        group.MapDelete("/Delete", async (int id, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operadores_Delete").WithDisplayName("Delete Operadores");
    }
}