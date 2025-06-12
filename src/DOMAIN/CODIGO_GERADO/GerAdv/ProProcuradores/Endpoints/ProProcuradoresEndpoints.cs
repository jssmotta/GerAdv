#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProProcuradoresEndpoints
{
    public static IEndpointRouteBuilder MapProProcuradoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProProcuradores").WithTags("ProProcuradores").RequireAuthorization();
        MapProProcuradoresRoutes(group);
        return app;
    }

    private static void MapProProcuradoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProProcuradoresService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_GetAll").WithDisplayName("Get All ProProcuradores");
        group.MapPost("/Filter", async (Filters.FilterProProcuradores filtro, string uri, IProProcuradoresService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_Filter").WithDisplayName("Filter ProProcuradores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProProcuradoresService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProProcuradores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_GetById").WithDisplayName("Get ProProcuradores By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProProcuradores? filtro, string uri, IProProcuradoresService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProProcuradores_GetListN").WithDisplayName("Get ProProcuradores List N");
        group.MapPost("/AddAndUpdate", async (Models.ProProcuradores regProProcuradores, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            var result = await service.AddAndUpdate(regProProcuradores, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_AddAndUpdate").WithDisplayName("Add or Update ProProcuradores");
        group.MapDelete("/Delete", async (int id, string uri, IProProcuradoresValidation validation, IProProcuradoresWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IProProcuradoresService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProProcuradores_Delete").WithDisplayName("Delete ProProcuradores");
    }
}