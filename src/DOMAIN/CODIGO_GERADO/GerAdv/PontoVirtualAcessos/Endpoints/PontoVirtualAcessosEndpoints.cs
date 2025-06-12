#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PontoVirtualAcessosEndpoints
{
    public static IEndpointRouteBuilder MapPontoVirtualAcessosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PontoVirtualAcessos").WithTags("PontoVirtualAcessos").RequireAuthorization();
        MapPontoVirtualAcessosRoutes(group);
        return app;
    }

    private static void MapPontoVirtualAcessosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPontoVirtualAcessosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_GetAll").WithDisplayName("Get All PontoVirtualAcessos");
        group.MapPost("/Filter", async (Filters.FilterPontoVirtualAcessos filtro, string uri, IPontoVirtualAcessosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_Filter").WithDisplayName("Filter PontoVirtualAcessos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPontoVirtualAcessosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PontoVirtualAcessos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_GetById").WithDisplayName("Get PontoVirtualAcessos By Id");
        group.MapPost("/AddAndUpdate", async (Models.PontoVirtualAcessos regPontoVirtualAcessos, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            var result = await service.AddAndUpdate(regPontoVirtualAcessos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_AddAndUpdate").WithDisplayName("Add or Update PontoVirtualAcessos");
        group.MapDelete("/Delete", async (int id, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_Delete").WithDisplayName("Delete PontoVirtualAcessos");
    }
}