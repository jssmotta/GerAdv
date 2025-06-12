#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Diario2Endpoints
{
    public static IEndpointRouteBuilder MapDiario2Endpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Diario2").WithTags("Diario2").RequireAuthorization();
        MapDiario2Routes(group);
        return app;
    }

    private static void MapDiario2Routes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDiario2Service service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Diario2_GetAll").WithDisplayName("Get All Diario2");
        group.MapPost("/Filter", async (Filters.FilterDiario2 filtro, string uri, IDiario2Service service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Diario2_Filter").WithDisplayName("Filter Diario2");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDiario2Service service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Diario2 found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Diario2_GetById").WithDisplayName("Get Diario2 By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterDiario2? filtro, string uri, IDiario2Service service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Diario2_GetListN").WithDisplayName("Get Diario2 List N");
        group.MapPost("/AddAndUpdate", async (Models.Diario2 regDiario2, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            var result = await service.AddAndUpdate(regDiario2, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Diario2_AddAndUpdate").WithDisplayName("Add or Update Diario2");
        group.MapDelete("/Delete", async (int id, string uri, IDiario2Validation validation, IDiario2Writer writer, IOperadorReader operadorReader, IClientesReader clientesReader, IDiario2Service service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Diario2_Delete").WithDisplayName("Delete Diario2");
    }
}