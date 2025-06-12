#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorEndpoints
{
    public static IEndpointRouteBuilder MapOperadorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Operador").WithTags("Operador").RequireAuthorization();
        MapOperadorRoutes(group);
        return app;
    }

    private static void MapOperadorRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Operador_GetAll").WithDisplayName("Get All Operador");
        group.MapPost("/Filter", async (Filters.FilterOperador filtro, string uri, IOperadorService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Operador_Filter").WithDisplayName("Filter Operador");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Operador found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operador_GetById").WithDisplayName("Get Operador By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperador? filtro, string uri, IOperadorService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Operador_GetListN").WithDisplayName("Get Operador List N");
        group.MapPost("/AddAndUpdate", async (Models.Operador regOperador, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            var result = await service.AddAndUpdate(regOperador, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Operador_AddAndUpdate").WithDisplayName("Add or Update Operador");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operador_Delete").WithDisplayName("Delete Operador");
    }
}