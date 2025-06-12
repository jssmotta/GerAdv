#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PenhoraEndpoints
{
    public static IEndpointRouteBuilder MapPenhoraEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Penhora").WithTags("Penhora").RequireAuthorization();
        MapPenhoraRoutes(group);
        return app;
    }

    private static void MapPenhoraRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPenhoraService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Penhora_GetAll").WithDisplayName("Get All Penhora");
        group.MapPost("/Filter", async (Filters.FilterPenhora filtro, string uri, IPenhoraService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Penhora_Filter").WithDisplayName("Filter Penhora");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPenhoraService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Penhora found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Penhora_GetById").WithDisplayName("Get Penhora By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterPenhora? filtro, string uri, IPenhoraService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Penhora_GetListN").WithDisplayName("Get Penhora List N");
        group.MapPost("/AddAndUpdate", async (Models.Penhora regPenhora, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            var result = await service.AddAndUpdate(regPenhora, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Penhora_AddAndUpdate").WithDisplayName("Add or Update Penhora");
        group.MapDelete("/Delete", async (int id, string uri, IPenhoraValidation validation, IPenhoraWriter writer, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, IPenhoraService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Penhora_Delete").WithDisplayName("Delete Penhora");
    }
}