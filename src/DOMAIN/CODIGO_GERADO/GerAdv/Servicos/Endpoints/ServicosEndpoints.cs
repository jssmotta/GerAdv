#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ServicosEndpoints
{
    public static IEndpointRouteBuilder MapServicosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Servicos").WithTags("Servicos").RequireAuthorization();
        MapServicosRoutes(group);
        return app;
    }

    private static void MapServicosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IServicosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Servicos_GetAll").WithDisplayName("Get All Servicos");
        group.MapPost("/Filter", async (Filters.FilterServicos filtro, string uri, IServicosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Servicos_Filter").WithDisplayName("Filter Servicos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IServicosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Servicos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Servicos_GetById").WithDisplayName("Get Servicos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterServicos? filtro, string uri, IServicosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Servicos_GetListN").WithDisplayName("Get Servicos List N");
        group.MapPost("/AddAndUpdate", async (Models.Servicos regServicos, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            var result = await service.AddAndUpdate(regServicos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Servicos_AddAndUpdate").WithDisplayName("Add or Update Servicos");
        group.MapDelete("/Delete", async (int id, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Servicos_Delete").WithDisplayName("Delete Servicos");
    }
}