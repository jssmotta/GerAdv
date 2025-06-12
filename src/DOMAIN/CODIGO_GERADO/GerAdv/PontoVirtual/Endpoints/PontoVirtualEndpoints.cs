#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PontoVirtualEndpoints
{
    public static IEndpointRouteBuilder MapPontoVirtualEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PontoVirtual").WithTags("PontoVirtual").RequireAuthorization();
        MapPontoVirtualRoutes(group);
        return app;
    }

    private static void MapPontoVirtualRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPontoVirtualService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtual_GetAll").WithDisplayName("Get All PontoVirtual");
        group.MapPost("/Filter", async (Filters.FilterPontoVirtual filtro, string uri, IPontoVirtualService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtual_Filter").WithDisplayName("Filter PontoVirtual");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPontoVirtualService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PontoVirtual found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtual_GetById").WithDisplayName("Get PontoVirtual By Id");
        group.MapPost("/AddAndUpdate", async (Models.PontoVirtual regPontoVirtual, string uri, IPontoVirtualValidation validation, IPontoVirtualWriter writer, IOperadorReader operadorReader, IPontoVirtualService service) =>
        {
            var result = await service.AddAndUpdate(regPontoVirtual, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtual_AddAndUpdate").WithDisplayName("Add or Update PontoVirtual");
        group.MapDelete("/Delete", async (int id, string uri, IPontoVirtualValidation validation, IPontoVirtualWriter writer, IOperadorReader operadorReader, IPontoVirtualService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtual_Delete").WithDisplayName("Delete PontoVirtual");
    }
}